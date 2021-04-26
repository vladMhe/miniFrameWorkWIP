using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using t3;
using t3.Pages;

namespace WordPressSetup 
{ 
    class WordPressSetupTests
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
        WPHomePage wpHome = new WPHomePage();
        WPSettingsPage wpSettings = new WPSettingsPage();

        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("Chrome");
            helper.BrowserManage();
            helper.NavigateTo("https://wordpress.com/");
            wpLogin.logIn("wpsvcg@gmail.com", "auto123auto");
        }
        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        /*Logging in using an invalid userName*/
        [Test]
        public void InvalidUserNameLogin()
        {

            wpHome.NameYoursiteText.Click();
            wpHome.NameYoursiteButton.Click();
            Assert.AreEqual(true, wpSettings.SettingsTitle.Displayed);

        }

        

    }
}
