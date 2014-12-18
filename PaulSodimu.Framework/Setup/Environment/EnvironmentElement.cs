using System.Configuration;

namespace PaulSodimu.Framework.Setup
{
    public class EnvironmentElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = false)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("pageTitle", IsRequired = true)]
        public string PageTitle
        {
            get { return (string)this["pageTitle"]; }
            set { this["pageTitle"] = value; }
        }

    }


}
