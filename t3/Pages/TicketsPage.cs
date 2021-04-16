using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class TicketsPage: DriverHelper
    {
     /*Selectors*/
        IWebElement ticketTitle => Driver.FindElement(By.XPath("//*[@id=\"container\"]/header/div[1]/nav[2]/ul/li[1]/a"));
        IWebElement ticketParagraph => Driver.FindElement(By.XPath("//*[@id=\"container\"]/section/div/h1"));

        public IWebElement TicketTitle{get{return ticketTitle;}}
        public IWebElement TicketParagraph { get { return ticketParagraph; } }

     /*Actions*/
        public void TicketTitleSelect() => TicketTitle.Click();


    }
}
