using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using t3.Pages;

namespace t3
{
    public class DriverHelper
    {
        public static IWebDriver Driver { get; set; }

        //Initialize Chrome Driver (more arguments will be added latar)
        public void ChromeDriver(String size)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument(size);
            Driver = new ChromeDriver(options);
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
