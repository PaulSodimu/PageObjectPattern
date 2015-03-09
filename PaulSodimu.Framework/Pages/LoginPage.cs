using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PaulSodimu.Framework.Pages
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "user_login")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "user_password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "commit")]
        public IWebElement btnLogin { get; set; }

        public void Logon()
        {
            Logon("User", "Password");
        }

        /// <summary>
        /// This method will attempt to log in using the credentials provided
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Logon(string userName, string password)
        {
            WaitForLoad();

            //Clear the txt box just incase it has values in it already then input the ones we want
            txtUserName.Clear();
            txtUserName.SendKeys(userName);

            txtPassword.Clear();
            txtPassword.SendKeys(password);

            //Click the login button
            btnLogin.Click();
             
        }

    }
}
