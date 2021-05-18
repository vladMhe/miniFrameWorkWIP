using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class WPLoginPage : DriverHelper
    {
    /*Selectors*/
        IWebElement acceptCookieButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Got it!')]"));
        IWebElement welcomeTitle => Driver.FindElement(By.XPath("//span[contains(text(), 'Welcome to the world’s most')]"));
        IWebElement logInButtonTitle => Driver.FindElement(By.XPath("//a[@title=\"Log In\"]"));
        IWebElement userField => Driver.FindElement(By.Id("usernameOrEmail"));
        IWebElement passwordField => Driver.FindElement(By.Id("password"));
        IWebElement continueButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Continue')]"));
        IWebElement loginButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Log In')]"));
        IWebElement userNotExistMessage => Driver.FindElement(By.XPath("//a[contains(text(), 'create a new account')]"));
        IWebElement userEmptyField => Driver.FindElement(By.XPath("//input[@name=\"usernameOrEmail\"]"));
        IWebElement wrongPassword => Driver.FindElement(By.XPath("//*[@class=\"form-input-validation is-error\"]"));
        IWebElement myHomeTitle => Driver.FindElement(By.XPath("//img[@alt=\"My Profile\"]"));

        public IWebElement AcceptCookieButton { get { return acceptCookieButton; } }
        public IWebElement WelcomeTitle { get { return welcomeTitle; } }
        public IWebElement LogInButtonTitle { get { return logInButtonTitle; } }
        public IWebElement UserField { get { return userField; } }
        public IWebElement PasswordField { get { return passwordField; } }
        public IWebElement ContinueButton { get { return continueButton; } }
        public IWebElement LoginButton { get { return loginButton; } }
        public IWebElement UserNotExistMessage { get { return userNotExistMessage; } }
        public IWebElement UserEmptyField { get { return userEmptyField; } }
        public IWebElement WrongPassword { get { return wrongPassword; } }
        public IWebElement MyHomeTitle { get { return myHomeTitle; } }


    /*Actions*/

        //Login Method
        public void logIn(String userName, String password)
        {
            //conditionals should be added here
            logInButtonTitle.Click();
            UserField.SendKeys(userName);
            ContinueButton.Click();
            try
            {
                PasswordField.SendKeys(password);
            }
            catch(ElementNotInteractableException)
            {
                Console.WriteLine("UserField Element not Interactable");
            }
            try
            {
                LoginButton.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No Element is displayed");
            }
        }
        
        public void AcceptCookie()
        {
            try
            {
                AcceptCookieButton.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cookie button not found");
            }
        }





    }
}

