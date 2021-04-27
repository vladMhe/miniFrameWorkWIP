using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class WPSettingsPage:DriverHelper
    {
        IWebElement settingsTitle => Driver.FindElement(By.XPath("//h1[contains(text(),'Settings')]"));



        public IWebElement SettingsTitle { get { return settingsTitle; } }
    }
}
