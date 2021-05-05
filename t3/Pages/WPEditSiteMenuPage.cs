using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class WPEditSiteMenuPage:DriverHelper
    {
        IWebElement acceptCookie => Driver.FindElement(By.XPath("//input[@value=\"Close and accept\"]"));
        IWebElement siteIdentifyButton => Driver.FindElement(By.XPath("//h3[contains(text(), 'Site Identity')]"));


        public IWebElement SiteIdentifyButton { get { return siteIdentifyButton; } }
        public IWebElement AcceptCookie { get { return acceptCookie; } }

    }
}
