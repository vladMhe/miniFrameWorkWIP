using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    //IWebElement nameyoursiteText = Driver.FindElement(By.XPath(""));

    class WPHomePage :DriverHelper
    {
    /*Selectors*/
        IWebElement nameYoursiteText => Driver.FindElement(By.XPath("//h6[contains(text(), 'Name your site')]"));
        IWebElement nameYoursiteButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Name your site')]"));
        IWebElement updateHomePageButton => Driver.FindElement(By.XPath("//h6[contains(text(), 'Update your Home page')]"));
        IWebElement editHomePageButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Edit homepage')]"));
        IWebElement myHome => Driver.FindElement(By.XPath("//*[@data-e2e-sidebar=\"My Home\"]"));
        IWebElement visiSiteButton => Driver.FindElement(By.XPath("//a[contains(text(), 'Visit site')]"));
        IWebElement editSiteMenuButton => Driver.FindElement(By.XPath("//h6[contains(text(), 'Edit the site menu')]"));
        IWebElement addMenuButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Add a menu')]"));

        public IWebElement NameYoursiteText { get { return nameYoursiteText; } }
        public IWebElement NameYoursiteButton { get { return nameYoursiteButton; } }
        public IWebElement UpdateHomePageButton { get { return updateHomePageButton; } }
        public IWebElement EditHomePageButton { get { return editHomePageButton; } }
        public IWebElement MyHome { get { return myHome; } }
        public IWebElement VisiSiteButton { get { return visiSiteButton; } }
        public IWebElement EditSiteMenuButton { get { return editSiteMenuButton; } }
        public IWebElement AddMenuButton { get { return addMenuButton; } }



    }
}
