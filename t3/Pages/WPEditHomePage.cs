using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace t3.Pages
{
    class WPEditHomePage : DriverHelper
    {
        /*Selectors*/
        IWebElement siteBody => Driver.FindElement(By.XPath("//div[@class=\"wpcom-site\"]"));
        IWebElement addElementButton => Driver.FindElement(By.XPath("//*[local-name()='svg' and @xmlns='http://www.w3.org/2000/svg']"));
        IWebElement tryAgain => Driver.FindElement(By.XPath("//h1[contains(text(), 'Edit Page']/div/div/div/div/div/div"));
        IWebElement tryAgain2 => Driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div/div[2]/div/div/button[1]"));

        public IWebElement SiteBody { get { return siteBody; } }
        public IWebElement AddElementButton { get { return addElementButton; } }
        public IWebElement TryAgain { get { return tryAgain2; } }

    }
}