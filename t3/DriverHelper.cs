using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using t3.Pages;

namespace t3
{
    public class DriverHelper
    {
        public static IWebDriver Driver { get; set; }

        /*Initialize browser driver based on passed argument*/
        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    Driver = new ChromeDriver(options);
                    break;
                case "FireFox":
                    Driver = new FirefoxDriver();
                    break;
                case "IE":
                    Driver = new InternetExplorerDriver();
                    break;
            }
        }

        /*Navigate to any URL*/
        public void NavigateTo(String url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        /*Terminates the driver session*/
        public void EndSession()
        {
            Driver.Quit();
        }

        /*Browser arguments*/
        public void BrowserManage()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        /*Read specific lines from a local file*/
        public string ReadSpecificLine(string filePath, int lineNumber)
        {
            string content = null;
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    for (int i = 1; i < lineNumber; i++)
                    {
                        file.ReadLine();

                        if (file.EndOfStream)
                        {
                            Console.WriteLine($"End of file.  The file only contains {i} lines.");
                            break;
                        }
                    }
                    content = file.ReadLine();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error reading the file: ");
                Console.WriteLine(e.Message);
            }

            return content;

        }



        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }





        public IWebElement WaitElementXpath(String xpathValue) {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpathValue)));
            return SearchResult;
        }

        //Assert Method based on the text value from a selector/element
        public void AssertByElementText(String textString, IWebElement seleniumSelector)
        {
            string elementText = seleniumSelector.Text;
            Assert.AreEqual(textString, elementText);
        }

        public bool IsElementDisplayed(By element)
        {
            if (Driver.FindElements(element).Count > 0)
            {
                if (Driver.FindElement(element).Displayed)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }

        public bool IsElementEnabled( By element)
        {
            if (Driver.FindElements(element).Count > 0)
            {
                if (Driver.FindElement(element).Enabled)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        internal void IsElementEnabled(IWebElement existingAdress)
        {
            throw new NotImplementedException();
        }

        public void WaitElement(String xpath)
        {
            

        }

    }
}
