using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using t3;
using t3.Pages;

namespace WordPressSetup 
{ 
    class WordPressSetupTests:DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
        WPHomePage wpHome = new WPHomePage();
        WPSettingsPage wpSettings = new WPSettingsPage();
        WebsitePage wpWeb = new WebsitePage();

        //Add Path to stored values from the local text file, then the corresponding line
        String user => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 1);
        String password => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 2);

        [SetUp]
        public void Setup()
        {
            //Add Path to stored values from the local text file, then the corresponding line
           
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

        [Test]
        public void ChangeSiteBasicSettings()
        {
            //Enter Site Name and Description
            wpHome.NameYoursiteText.Click();
            wpHome.NameYoursiteButton.Click();
            Assert.AreEqual(true, wpSettings.SettingsTitle.Displayed);

            wpSettings.SiteNameAndDescription("Site1", "This is a site");
            wpSettings.SelectLanguageFAux("Africa and Middle East", "Afrikaans");
            helper.AssertByElementText("Afrikaans", wpSettings.LanguagePickButton);

            //Configure Time Zone
            helper.ScrollToElement(wpSettings.TimeZone);
            wpSettings.SelectTimeZone("Bucharest");
            wpSettings.SaveSettingsButton.Click();

            //Check if new configured settings are reflected on the WebPage
            helper.ScrollToElement(wpHome.MyHome);
            wpHome.MyHome.Click();
            wpHome.VisiSiteButton.Click();
            helper.WaitElement(wpWeb.SiteTitle);
            helper.AssertByElementText("Site1", wpWeb.SiteTitle);
            helper.WaitElement(wpWeb.SiteDescription);
            helper.AssertByElementText("This is a site", wpWeb.SiteDescription);
        }





    }
}
