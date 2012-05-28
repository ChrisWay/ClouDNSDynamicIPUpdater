using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ClouDNSIPUpdater.Library.Config;

namespace ClouDNSIPUpdater.Library
{
    public class DynamicUrlUpdater
    {
        /* 1. Start timer
         * 2. Get config properties with urls to call
         * 3. Timer fires - send request to all urls (Tasks)
         * 4. Check responses - log errors.
         */

        public void Update()
        {
            var handlerTasks = new List<Task>();


            foreach (ClouDNSInstanceElement instance in ClouDNSConfig.GetAllInstances())
            {
                ClouDNSInstanceElement instanceCopy = instance;

                var updaterTask = Task<Tuple<string, ClouDNSInstanceElement>>.Factory.StartNew(i =>
                                                                                               {
                                                                                                   var webClient = new WebClient();
                                                                                                   var configSetting = (ClouDNSInstanceElement) i;

                                                                                                   string result = webClient.DownloadString(configSetting.DynamicUrl);

                                                                                                   return new Tuple<string, ClouDNSInstanceElement>(result, configSetting);
                                                                                               }, instanceCopy);
                updaterTask.ContinueWith(task =>
                                         {
                                             if (ResponseParser.CheckResponse(task.Result.Item1))
                                                 Log(string.Format("Success: {0}", task.Result.Item2.Name));
                                             else
                                                 Log(string.Format("Failure: {0}", task.Result.Item2.Name));
                                         });

                var handlerTask = updaterTask.ContinueWith(task =>
                                                           {
                                                               foreach (var e in task.Exception.Flatten().InnerExceptions)
                                                                   Log("Observed exception: " + e.Message);
                                                           },
                                                           TaskContinuationOptions.OnlyOnFaulted);


                handlerTasks.Add(handlerTask);
            }

            Task.WaitAll(handlerTasks.ToArray());
        }

        public void Log(string message)
        {
            //TODO Implement logging!
        }
    }
}