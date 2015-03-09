using OpenQA.Selenium.Support.PageObjects;
using PaulSodimu.Framework.Setup;
using System;
using System.Collections;
using System.Configuration;

namespace PaulSodimu.Framework.Pages
{
    //This class allows access to system pages through the tests
    public static class Pages
    {
        public static void Initilise()
        {
            ArrayList pages = new ArrayList();

            foreach (var page in pages)
            {
               
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                PageFactory.InitElements(Browser.Driver, loginPage);
                return loginPage;
            }
        }
    }

}
