using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using t3;
using t3.Pages;

namespace WordPressLogin 
{ 
    class WordPressLogin
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();
      

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
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn("wpsvcg@gmail.com@", "auto123auto");
            Assert.AreEqual(true, wpLogin.UserNotExistMessage.Displayed);
        }

        /*Logging in using an invalid password*/
        [Test]
        public void InvalidPasswordLogin()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn("wpsvcg@gmail.com", "auto123aut@");
            Assert.AreEqual(true, wpLogin.WrongPassword.Displayed);
        }

        /*Checking field validations*/
        [Test]
        public void EmptyFieldsValidation()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn("", "");
            Assert.AreEqual(true, wpLogin.UserEmptyField.Displayed);
            wpLogin.UserField.SendKeys("wpsvcg@gmail.com");
            wpLogin.ContinueButton.Click();
            wpLogin.LoginButton.Click();
            Assert.AreEqual(true, wpLogin.PasswordField.Displayed);
        }

        /*Logging in using successfully*/
        [Test]
        public void SuccesfulLogin()
        {
            var userT = ConfigurationManager.AppSettings["user"];
            var passwordT = ConfigurationManager.AppSettings["password"];
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn(userT, passwordT);
            Assert.AreEqual(true, wpLogin.MyHomeTitle.Displayed);
        }

    }
}
