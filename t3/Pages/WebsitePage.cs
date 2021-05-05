using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class WebsitePage:DriverHelper
    {
     /*Selectors*/
        IWebElement siteTitle => Driver.FindElement(By.XPath("//p[contains(@class, 'site-title')]"));
        IWebElement siteDescription => Driver.FindElement(By.XPath("//p[contains(@class, 'site-description')]"));
        public IWebElement SiteTitle { get { return siteTitle; } }
        public IWebElement SiteDescription { get { return siteDescription; } }









    }
}
