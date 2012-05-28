using System;
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
            foreach (ClouDNSInstanceElement instance in ClouDNSConfig.GetAllInstances())
            {
                ClouDNSInstanceElement instanceCopy = instance;

                Task<Tuple<string, ClouDNSInstanceElement>>.Factory.StartNew(i =>
                                                                             {
                                                                                 var webClient = new WebClient();
                                                                                 var configSetting = (ClouDNSInstanceElement) i;

                                                                                 return new Tuple<string, ClouDNSInstanceElement>(
                                                                                     webClient.DownloadString(configSetting.DynamicUrl), configSetting);
                                                                             }, instanceCopy)
                    .ContinueWith(task =>
                                  {
                                      if (ResponseParser.CheckResponse(task.Result.Item1))
                                          Log(string.Format("Success: {0}", task.Result.Item2.Name));
                                      else
                                          Log(string.Format("Failure: {0}", task.Result.Item2.Name));
                                  });
            }
        }

        public void Log(string message)
        {
            //TODO Implement logging!
        }
    }
}