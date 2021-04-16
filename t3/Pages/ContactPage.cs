using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class ContactPage : DriverHelper
    {



        IWebElement Contact => Driver.FindElement(By.XPath("/html/body/nav/div[1]/ul/li[2]/a"));
        public void NavigateToContact() => Contact.Click();

        IWebElement Email => Driver.FindElement(By.Id("recipient-email"));
        IWebElement Name => Driver.FindElement(By.Id("recipient-name"));
        IWebElement Message => Driver.FindElement(By.Id("message-text"));
        IWebElement Submit => Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/button[2]"));

        

        public void FillInForm(String email, String name, String message)
        {

            Email.SendKeys(email);
            Name.SendKeys(name);
            Message.SendKeys(message);
            Submit.Click();

        }

    }

}