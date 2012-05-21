using System.Configuration;

namespace ClouDNSIPUpdater.Library.Config
{
    public class ClouDNSConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
        public ClouDNSInstanceCollection Instances
        {
            get { return (ClouDNSInstanceCollection)this[""]; }
            set { this[""] = value; }
        }
    }
}
