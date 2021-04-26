using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using t3;
using t3.Pages;

namespace WordPressLogin 
{ 
    class WordPressLogin
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpPage = new WPLoginPage();

        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("Chrome");
            helper.BrowserManage();
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
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpPage.WelcomeTitle.Displayed);
            wpPage.logIn("wpsvcg@gmail.com@", "auto123auto");
            Assert.AreEqual(true, wpPage.UserNotExistMessage.Displayed);
        }

        /*Logging in using an invalid password*/
        [Test]
        public void InvalidPasswordLogin()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpPage.WelcomeTitle.Displayed);
            wpPage.logIn("wpsvcg@gmail.com", "auto123aut@");
            Assert.AreEqual(true, wpPage.WrongPassword.Displayed);
        }

        /*Checking field validations*/
        [Test]
        public void EmptyFieldsValidation()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpPage.WelcomeTitle.Displayed);
            wpPage.logIn("", "");
            Assert.AreEqual(true, wpPage.UserEmptyField.Displayed);
            wpPage.UserField.SendKeys("wpsvcg@gmail.com");
            wpPage.ContinueButton.Click();
            wpPage.LoginButton.Click();
            Assert.AreEqual(true, wpPage.PasswordField.Displayed);
        }

        /*Logging in using successfully*/
        [Test]
        public void SuccesfulLogin()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpPage.WelcomeTitle.Displayed);
            wpPage.logIn("wpsvcg@gmail.com", "auto123auto");
            Assert.AreEqual(true, wpPage.MyHomeTitle.Displayed);
        }

    }
}
