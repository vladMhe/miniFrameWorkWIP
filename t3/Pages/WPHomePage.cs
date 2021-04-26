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


        public IWebElement NameYoursiteText { get { return nameYoursiteText; } }
        public IWebElement NameYoursiteButton { get { return nameYoursiteButton; } }


    }
}
