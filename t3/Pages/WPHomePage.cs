using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    //IWebElement nameyoursiteText = Driver.FindElement(By.XPath(""));

    class WPHomePage :DriverHelper
    {
        IWebElement nameYoursiteText => Driver.FindElement(By.XPath("//h6[contains(text(), 'Name your site')]"));
        IWebElement nameYoursiteButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Name your site')]"));
        IWebElement myHome => Driver.FindElement(By.XPath("//*[@data-e2e-sidebar=\"My Home\"]"));
        IWebElement visiSiteButton => Driver.FindElement(By.XPath("//a[contains(text(), 'Visit site')]"));

        /*TO BE MOVED*/
        IWebElement siteTitle => Driver.FindElement(By.XPath("//p[contains(@class, 'site-title')]"));
        IWebElement siteDescription => Driver.FindElement(By.XPath("//p[contains(@class, 'site-description')]"));
        public IWebElement SiteTitle { get { return siteTitle; } }
        public IWebElement SiteDescription { get { return siteDescription; } }

        /*TO BE MOVED*/


        public IWebElement NameYoursiteText { get { return nameYoursiteText; } }
        public IWebElement NameYoursiteButton { get { return nameYoursiteButton; } }
        public IWebElement MyHome { get { return myHome; } }
        public IWebElement VisiSiteButton { get { return visiSiteButton; } }


    }
}
