using System.Configuration;

namespace PaulSodimu.Framework.Setup
{
    public class EnvironmentCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EnvironmentElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnvironmentElement)element).Name;
        }
    }
}