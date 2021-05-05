using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using t3;
using t3.Pages;

namespace MenuSetup
{
    class WordPressEditMenuTests:DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
        WPHomePage wpHome = new WPHomePage();
        WPEditSiteMenuPage wpEditMenu = new WPEditSiteMenuPage();

        //Add Path to stored values from the local text file, then the corresponding line
        String user => helper.ReadSpecificLine(@"D:\t10\t3\TestData\credentials.txt", 1);
        String password => helper.ReadSpecificLine(@"D:\t10\t3\TestData\credentials.txt", 2);

        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("Chrome");
            helper.BrowserManage();
            helper.NavigateTo("https://wordpress.com/");
            wpLogin.logIn(user, password);
            wpLogin.AcceptCookieButton.Click();
        }

        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        //Configuring Site Menu
        [Test, Order(1)]
        public void t1()
        {
            wpHome.EditSiteMenuButton.Click();
            wpHome.AddMenuButton.Click();
            Thread.Sleep(5000);
         
            Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("iframe[title='Customizer']")));

            helper.WaitElement(wpEditMenu.SiteIdentifyButton);
            Assert.AreEqual(true, wpEditMenu.SiteIdentifyButton.Displayed);
            helper.WaitElement(wpEditMenu.SiteIdentifyButton);

            wpEditMenu.SiteIdentifyButton.Click();
        }
    }
}
