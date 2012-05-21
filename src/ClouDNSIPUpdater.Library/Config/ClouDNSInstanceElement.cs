using System.Configuration;

namespace ClouDNSIPUpdater.Library.Config
{
    public class ClouDNSInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)base["Name"]; }
            set { base["Name"] = value; }
        }

        [ConfigurationProperty("DynamicURL", IsKey = false, IsRequired = true)]
        public string DynamicUrl
        {
            get { return (string)base["DynamicURL"]; }
            set { base["DynamicURL"] = value; }
        }
    }
}