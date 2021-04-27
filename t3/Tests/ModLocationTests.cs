using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using t3;
using t3.Pages;

namespace ModPizzaLocation
{
    public class ModLocationTests
    {

        DriverHelper helper = new DriverHelper();
        ModLocationsPage locationsPage = new ModLocationsPage();
       

        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("FireFox");
        }

        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        //Verifying All, Open and Coming Soon locations
        [Test, Order(1)]
        public void CheckingStatuses()
        {
            helper.NavigateTo("https://modpizza.com/");
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
            helper.NavigateTo("https://modpizza.com/");
            //Reaching Locations Page
            locationsPage.LocationsCategorySelect();
            helper.AssertByElementText("LOCATIONS", locationsPage.LocationsTitle);

            //Searching for a valid location
            locationsPage.SearchingForLocation("14 palm");
            helper.WaitElementXpath("//a[contains(@href,'https://modpizza.com/locations/')]");
            Assert.AreEqual(true, locationsPage.ExistingAdress.Displayed);
            locationsPage.LocationsSearchBar.Clear();

            //Searching for an invalid location also using an invalid input
            locationsPage.SearchingForLocation("~!@@##2");
            locationsPage.MyLocationButton.Click();
            
        }








    }
}
