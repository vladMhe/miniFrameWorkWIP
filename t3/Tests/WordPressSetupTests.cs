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

        //Add Path to stored values from the local text file, then the corresponding line
        String user => helper.ReadSpecificLine(@"D:\t10\t3\TestData\credentials.txt", 1);
        String password => helper.ReadSpecificLine(@"D:\t10\t3\TestData\credentials.txt", 2);

        [SetUp]
        public void Setup()
        {
            //Add Path to stored values from the local text file, then the corresponding line
           
            helper.InitBrowser("Chrome");
            helper.BrowserManage();
            helper.NavigateTo("https://wordpress.com/");
            wpLogin.logIn(user, password);
            wpSettings.AcceptCookieButton.Click();
        }
        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        /*Logging in using an invalid userName*/
        [Test]
        public void ChangeSiteBasicSettings()
        {
            wpHome.NameYoursiteText.Click();
            wpHome.NameYoursiteButton.Click();
            Assert.AreEqual(true, wpSettings.SettingsTitle.Displayed);
            wpSettings.SiteNameAndDescription("Site1", "This is a site");
            wpSettings.SelectLanguageFAux("Africa and Middle East", "Afrikaans");
            helper.AssertByElementText("Afrikaans", wpSettings.LanguagePickButton);
            wpSettings.SelectTimeZone("Bucharest");
            wpSettings.SaveSettingsButton.Click();
            Assert.AreEqual(true, wpSettings.SaveAlert.Displayed);

            wpHome.MyHome.Click();
            wpHome.VisiSiteButton.Click();

            helper.AssertByElementText("Site1", wpHome.SiteTitle);
            helper.AssertByElementText("This is a site", wpHome.SiteDescription);


        }



    }
}
