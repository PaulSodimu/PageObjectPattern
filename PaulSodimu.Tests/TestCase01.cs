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
            //Act
            Pages.HomePage.Goto();

            //Assert
            Assert.IsTrue(Pages.HomePage.IsAt());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
