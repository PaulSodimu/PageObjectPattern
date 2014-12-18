using PaulSodimu.Framework.Common;
using PaulSodimu.Framework.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulSodimu.Framework.Pages
{
    public abstract class Page : PageObject
    {
        public static string Url { get; set; }
         
        protected Page()
        {
            Url = EnvironmentReader.get(GetType().Name).Url;
            PageTitle = EnvironmentReader.get(GetType().Name).PageTitle;
        }
         
        /// <summary>
        /// Navigates to the page URL.
        /// </summary>
        public void Goto()
        {
            try
            {
                Browser.Goto(Url);
                WaitForLoad();
            }
            catch (Exception e)
            {
                throw new Exception(GetType().Name + " could not be loaded. Check page url is correct in app.config." +
                                    " " + e.Message);
            }
        }

    }
}
