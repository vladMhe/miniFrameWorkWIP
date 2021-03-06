using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using t3;
using t3.Pages;

namespace WordPressSetup
{
    class WordPressEditHomePage : DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
        WPHomePage wpHome = new WPHomePage();
        WPEditHomePage wpEdit = new WPEditHomePage();

        //Add Path to stored values from the local text file, then the corresponding line
        String user => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 1);
        String password => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 2);

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

        [Test]
        public void InProgressForNow()
        {
            wpHome.UpdateHomePageButton.Click();
            wpHome.EditHomePageButton.Click();
         

        }





    }
}
