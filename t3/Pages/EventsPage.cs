using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class EventsPage:DriverHelper
    {
     /*Selectors*/
        IWebElement eventsTitle => Driver.FindElement(By.XPath(" //*[@id=\"container\"]/header/div[1]/nav[2]/ul/li[2]/a"));
        IWebElement eventsParagrahp => Driver.FindElement(By.XPath("//*[@id=\"container\"]/div[1]/h1"));

        public IWebElement EventsTitle { get { return eventsTitle; } }
        public IWebElement EventsParagrahp { get { return eventsParagrahp; } }

     /*Actions*/
        public void EventsTitleSelect() => EventsTitle.Click();







    }
}
