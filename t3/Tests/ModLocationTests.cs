using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using t3.Pages;

namespace t3
{
    public class ModLocationTests: DriverHelper
    {

        DriverHelper helper = new DriverHelper();
        ModLocationsPage locationsPage = new ModLocationsPage();

        [SetUp]
        public void Setup()
        {
            helper.ChromeDriver("--start-maximized");
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl("https://modpizza.com/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        //Verifying All, Open and Coming Soon locations
        [Test, Order(1)]
        public void CheckingStatuses()
        {
            //Reaching Locations Page
            locationsPage.LocationsCategorySelect();
            helper.AssertByElementText("LOCATIONS", locationsPage.LocationsTitle);

            //Selecting and Asserting All Statuses
            locationsPage.CheckBoxStatusAllSelect();
            Assert.AreEqual(true, locationsPage.CheckBoxStatusAll.Selected);

            //Selecting and Asserting Open Statuses
            locationsPage.CheckboxStatusOpenSelect();
            Assert.AreEqual(true, locationsPage.CheckboxStatusOpen.Selected);

            //Selecting and Asserting Coming Soon Statuses
            locationsPage.CheckboxStatusOpenComingSelect();
            Assert.AreEqual(true, locationsPage.CheckboxStatusComing.Selected);
            
        }

        [Test, Order(2)]
        public void SearchingLocations()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            //Reaching Locations Page
            locationsPage.LocationsCategorySelect();
            helper.AssertByElementText("LOCATIONS", locationsPage.LocationsTitle);

            //Searching for a valid location
            locationsPage.SearchingForLocation("14 palm");
            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//a[contains(@href,'https://modpizza.com/locations/')]")));
            Assert.AreEqual(true, locationsPage.ExistingAdress.Displayed);
            locationsPage.LocationsSearchBar.Clear();

            //Searching for an invalid location also using an invalid input
            locationsPage.SearchingForLocation("~!@@##2");
            locationsPage.MyLocationButton.Click();
            
        }








    }
}
