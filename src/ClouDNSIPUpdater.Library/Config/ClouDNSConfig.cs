using System.Collections.Generic;

namespace ClouDNSIPUpdater.Library.Config
{
    public class ClouDNSConfig
    {
        private static readonly Dictionary<string, ClouDNSInstanceElement> Instances;

        private ClouDNSConfig()
        {
        }

        static ClouDNSConfig()
        {
            Instances = new Dictionary<string, ClouDNSInstanceElement>();
            ClouDNSConfigSection sec = (ClouDNSConfigSection)System.Configuration.ConfigurationManager.GetSection("ClouDNSConfiguration");
            foreach (ClouDNSInstanceElement i in sec.Instances)
            {
                Instances.Add(i.Name, i);
            }
        }

        public static ClouDNSInstanceElement GetInstance(string instanceName)
        {
            return Instances[instanceName];
        }

        public static IEnumerable<ClouDNSInstanceElement> GetAllInstances()
        {
            return Instances.Values;
        }
    }
}
