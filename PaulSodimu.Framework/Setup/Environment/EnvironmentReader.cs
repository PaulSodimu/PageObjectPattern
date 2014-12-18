using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PaulSodimu.Framework.Setup
{
    public static class EnvironmentReader
    {
        public static EnvironmentElement get(string pageName)
        {
            var PageConfig = new List<EnvironmentElement>();

            var EnvironmentInfo =
                ConfigurationManager.GetSection(EnvironmentsDataSection.SectionName) as EnvironmentsDataSection;

            if (EnvironmentInfo != null)
            {
                PageConfig.AddRange(from EnvironmentElement environmentElement in EnvironmentInfo.Environment
                                    select new EnvironmentElement()
                                               {
                                                   Name = environmentElement.Name, Url = environmentElement.Url, PageTitle = environmentElement.PageTitle
                                               });
            }

            return PageConfig.First(x => x.Name == pageName);
        }
    }
}
