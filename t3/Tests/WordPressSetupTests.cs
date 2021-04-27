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
