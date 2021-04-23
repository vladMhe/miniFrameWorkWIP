using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class WPLoginPage : DriverHelper
    {
        IWebElement locationsTitle => Driver.FindElement(By.XPath("//span[contains(text(), 'Welcome to the world’s most')]"));
        IWebElement logInButton => Driver.FindElement(By.XPath("//a[@title=\"Log In\"]"));

        public IWebElement LocationsTitle { get { return locationsTitle; } }
        public IWebElement LogInButton { get { return logInButton; } }






        public void LogInButtonSelect()
        {
            LogInButton.Click();
        }

    }
}
