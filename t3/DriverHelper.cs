using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using t3.Pages;
using static System.Net.Mime.MediaTypeNames;

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
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
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

        //Waiting for element to be clickable
        public void WaitElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }

        //Scroll to Element
        public void ScrollToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element);
            action.Perform();
        }

        //public  IWebElement WaitUntilElementExists(By elementLocator, int timeout = 50)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
        //        return wait.Until(ExpectedConditions.ElementExists(elementLocator));
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
        //        throw;
        //    }
        //}


        //Waiting for element to exist by XPath - REFACTOR
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

        public static string[] MaxTiaaaaa()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"TestData\credentials.txt");
            string[] files = File.ReadAllLines(path);
            return files;
        }
       


    }
}
