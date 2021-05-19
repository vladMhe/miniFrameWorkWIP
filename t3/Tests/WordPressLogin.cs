using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using t3;
using t3.Pages;

namespace WordPressLogin 
{ 
    class WordPressLogin:DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpLogin = new WPLoginPage();

        //Add Path to stored values from the local text file, then the corresponding line
        String user => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 1);
        String password => helper.ReadSpecificLine(@"C:\a1\t3\TestData\credentials.txt", 2);


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
            Console.WriteLine();
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn("invalid@#@#", "same");
            Assert.AreEqual(true, wpLogin.UserNotExistMessage.Displayed);
        }

        /*Logging in using an invalid password*/
        [Test]
        public void InvalidPasswordLogin()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn(user, "invalidPass@");
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
            wpLogin.UserField.SendKeys(user);
            wpLogin.ContinueButton.Click();
            wpLogin.LoginButton.Click();
            Assert.AreEqual(true, wpLogin.PasswordField.Displayed);
        }

        /*Logging in using successfully*/
        [Test]
        public void SuccesfulLogin()
        {
            helper.NavigateTo("https://wordpress.com/");
            Assert.AreEqual(true, wpLogin.WelcomeTitle.Displayed);
            wpLogin.logIn(user, password);
            Assert.AreEqual(true, wpLogin.MyHomeTitle.Displayed);
        }

    }
}
