using System.Configuration;

namespace ClouDNSIPUpdater.Library.Config
{
    public class ClouDNSInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ClouDNSInstanceElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClouDNSInstanceElement)element).Name;
        }
    }
}