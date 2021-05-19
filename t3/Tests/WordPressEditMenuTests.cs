using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using t3;
using t3.Pages;

namespace WordPressMenuSetup
{
    class WordPressEditMenuTests:DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
        WPHomePage wpHome = new WPHomePage();
        WPEditSiteMenuPage wpEditMenu = new WPEditSiteMenuPage();

        //Add Path to stored values from the local text file, then the corresponding line
        String test = Path.Combine(TestContext.CurrentContext.TestDirectory, @"TestData\credentials.txt");

        String user => helper.ReadSpecificLine(test, 1);
        //current path ? ^ 
        //Add json

        String password => helper.ReadSpecificLine(test, 2);
        //encode encrypt password ^ - trigger at runtime

        /*Create one Nunit class with setup teardown*/
        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("Chrome");
            helper.BrowserManage();
            helper.NavigateTo("https://wordpress.com/");
            wpLogin.logIn(user, password);
            wpLogin.AcceptCookie();
        }

        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        //Configuring Site Menu
        [Test, Order(1)]
        public void UploadCustomLogo()
        {
            //create methods for these
            wpHome.EditSiteMenuButton.Click();
            
            wpHome.AddMenuButton.Click();
            //Needs to be replaced with proper handling
            Thread.Sleep(5000);
            //Needs to be replaced with proper handling

            Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("iframe[title='Customizer']")));

            helper.WaitElement(wpEditMenu.SiteIdentifyButton);
            Assert.AreEqual(true, wpEditMenu.SiteIdentifyButton.Displayed);
            helper.WaitElement(wpEditMenu.SiteIdentifyButton);

            wpEditMenu.SiteIdentifyButton.Click();
            helper.WaitElement(wpEditMenu.SelectLogoButton);
            wpEditMenu.SelectLogoButton.Click();
            wpEditMenu.ChangeToFileTab();
            Assert.AreEqual(true, wpEditMenu.InputFile.Enabled);
            wpEditMenu.UploadImage();

            helper.WaitElement(wpEditMenu.SelectUploadedImageButton);
            wpEditMenu.SelectUploadedImageButton.Click();
       
            wpEditMenu.DragImage(0, -150);
            helper.WaitElement(wpEditMenu.CropImageButton);
            wpEditMenu.CropImageButton.Click();
            helper.WaitElement(wpEditMenu.SaveButton);
            Assert.AreEqual(true, wpEditMenu.SaveButton.Displayed);
            //An check if image exist then replace method should be added here
        }
    }
}
