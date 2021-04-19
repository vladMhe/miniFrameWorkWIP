using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using t3.Pages;

namespace t3
{
    public class Tests: DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        TicketsPage ticketPage = new TicketsPage();
        EventsPage eventPage = new EventsPage();

        [SetUp]
        public void Setup()
        {
            helper.ChromeDriver("--start-maximized");
            Driver.Navigate().GoToUrl("https://www.houstonzoo.org/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }


        [Test, Order(1)]
        public void TestTicketPage()
        {
            helper.AssertByElementText("Tickets", ticketPage.TicketTitle);
            ticketPage.TicketTitleSelect();
            helper.AssertByElementText("We’re Ready to Welcome You Back to the Zoo!", ticketPage.TicketParagraph);
        }

        [Test, Order(2)]
        public void EventsPage()
        {
            helper.AssertByElementText("Host an Event", eventPage.EventsTitle);
            eventPage.EventsTitleSelect();
            helper.AssertByElementText("Host An Event", eventPage.EventsParagrahp);
        }

        //public void Test2()
        //{
        //    Driver.Navigate().GoToUrl("https://www.demoblaze.com/#");
        //    HomePage page = new HomePage();
        //    page.ClickHome();

        //    ContactPage contactPage = new ContactPage();
        //    contactPage.NavigateToContact();
        //    Thread.Sleep(4000);
        //    contactPage.FillInForm("test", "tessse2", "ttttt");
        //}
       
    }
}