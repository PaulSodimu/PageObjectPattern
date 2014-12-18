using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PaulSodimu.Framework.Setup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulSodimu.Framework.Common
{
    public abstract class PageObject
    {
        internal static string PageTitle { get; set; }

        /// <summary>
        /// Checks if the browser is on the calling page.
        /// </summary>
        /// <returns>Returs true if the browser is on the page and false if it isnt.</returns>
        public bool IsAt()
        {
            return Browser.Title.Contains(PageTitle);
        }

        /// <summary>
        /// Makes the browser wait until the page is loaded.
        /// </summary>
        internal void WaitForLoad()
        {
            var wait = Browser.Wait();

            try
            {
                wait.Until(p => p.Title == PageTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreenshot();
                throw;
            }

        }

        /// <summary>
        /// Makes the browser wait until an element that matches the given find by method is found on the page.
        /// </summary>
        /// <param name="elementDesc">The method to use to find the element</param>
        internal static void WaitFor(By elementDesc)
        {
            var wait = Browser.Wait();

            wait.Until(e => e.FindElement(elementDesc));
        }

        /// <summary>
        /// Makes the browser wait until the page title contains the specified string.
        /// </summary>
        /// <param name="keyWord">The keyword to be used for the wait.</param>
        internal void WaitForLoad(string keyWord)
        {
            var wait = Browser.Wait();

            try
            {
                wait.Until(p => p.Title.Contains(keyWord));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreenshot();
                throw;
            }

        }

        /// <summary>
        /// Waits until the page source contains the specified keyword.
        /// </summary>
        /// <param name="keyWord">The key word to be checked for.</param>
        internal void WaitFor(string keyWord)
        {
            var wait = Browser.Wait();
            try
            {
                wait.Until(p => p.PageSource.Contains(keyWord));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreenshot();
                throw;
            }

        }

        /// <summary>
        /// Checks if the current page contains the specified keyword.
        /// </summary>
        /// <param name="keyWord">The keyword to be checked for.</param>
        /// <returns>Returns true, if word is found and false if not.</returns>
        internal bool CheckPage(string keyWord)
        {
            return Browser.PageSource.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Takes a screenshot of the browser and stores it in the location specified in the app config file.
        /// </summary>
        internal void TakeScreenshot()
        {
            string captureLocation = Settings.CaptureLocation;
            string callingMethodName = new StackFrame(1, true).GetMethod().Name;
            string callingClassName = GetType().Name;
            string timeStamp = DateTime.Now.ToString("ddMMyyyyHHmmss");

            string filePath = captureLocation + callingMethodName + "ErrorCapture" + timeStamp + ".png";

            try
            {
                //TODO : Add more info to the filename and suitable location to save to 
                Screenshot ss = ((ITakesScreenshot)Browser.Driver).GetScreenshot();
                ss.SaveAsFile(filePath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine("TakeScreenshot encountered an error. " + e.Message);
                throw;
            }

            Console.WriteLine(callingClassName + "." + callingMethodName + " generated an error. A ScreenShot of the browser has been saved. " + filePath);
        }

        /// <summary>
        /// Returns an element on the page that matches the given method.
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        internal IWebElement Find(By by)
        {
            IWebElement element;

            try
            {
                element = Browser.Driver.FindElement(by);
            }
            catch (NoSuchElementException e1)
            {
                Console.WriteLine(GetType().Name + " could not find the element. " + by + e1.Message);
                TakeScreenshot();
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(GetType().Name + " encountered an error. " + e.Message);
                TakeScreenshot();
                throw;
            }

            return element;
        }

        /// <summary>
        /// Finds multiple web elements matching the given method.
        /// </summary>
        /// <param name="by">Method used to identify the elements.</param>
        /// <returns>Returns a collection of elements that match the given find method.</returns>
        internal ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            ReadOnlyCollection<IWebElement> elements;

            try
            {
                elements = Browser.Driver.FindElements(by);
            }
            catch (NoSuchElementException e1)
            {
                Console.WriteLine(GetType().Name + " could not find the element. " + by + e1.Message);
                TakeScreenshot();
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(GetType().Name + " encountered an error. " + e.Message);
                TakeScreenshot();
                throw;
            }

            return elements;
        }

        internal static void FocusOn(IWebElement element)
        {
            new Actions(Browser.getDriver).MoveToElement(element);
        }
    }
}
