using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaulSodimu.Framework;
using PaulSodimu.Framework.Pages;

namespace PaulSodimu.Tests
{
    [TestClass]
    public class TestCase01
    {
        [TestInitialize]
        public void SetupTest()
        {
            Browser.Open();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Pages.LoginPage.Goto();

            //Act
            Pages.LoginPage.Logon();

            //Assert - Check we are no longer at the login page. If we are still here we know the login has failed.
            Assert.IsFalse(Pages.LoginPage.IsAt());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
