using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class HomePage: DriverHelper
    {

        IWebElement Home => Driver.FindElement(By.XPath("/html/body/nav/div[1]/ul/li[1]/a"));
        public void ClickHome() => Home.Click();


    }
}
