using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace t3.Pages
{
    class ModLocationsPage: DriverHelper
    {
        /*Selectors*/

        IWebElement locationsCategory => Driver.FindElement(By.XPath("//a[@href=\"https://modpizza.com/location/\"]"));
        IWebElement locationsTitle => Driver.FindElement(By.XPath("//*[@class='page-header']/h1"));
        IWebElement checkboxStatusAll => Driver.FindElement(By.Id("search-all"));
        IWebElement checkboxStatusOpen => Driver.FindElement(By.Id("search-open"));
        IWebElement checkboxStatusComing => Driver.FindElement(By.Id("search-coming-soon"));
        IWebElement locationsSearchBar => Driver.FindElement(By.XPath("//input[@type=\"text\"]"));
        IWebElement searchButton => Driver.FindElement(By.XPath("//input[@type=\"text\"]/following-sibling::button"));
        IWebElement existingAdress => Driver.FindElement(By.XPath("//a[contains(@href,'https://modpizza.com/locations/')]"));

        public IWebElement LocationsCategory { get { return locationsCategory; } }
        public IWebElement LocationsTitle { get { return locationsTitle; } }
        public IWebElement CheckBoxStatusAll { get { return checkboxStatusAll; } }
        public IWebElement CheckboxStatusOpen { get { return checkboxStatusOpen; } }
        public IWebElement CheckboxStatusComing { get { return checkboxStatusComing; } }
        public IWebElement LocationsSearchBar { get { return locationsSearchBar; } }
        public IWebElement SearchButton { get { return searchButton; } }
        public IWebElement ExistingAdress { get { return existingAdress; } }


        /*Actions*/
        public void LocationsCategorySelect() => LocationsCategory.Click();
        public void LocationsTitleSelect() => LocationsTitle.Click();
        public void CheckBoxStatusAllSelect() => CheckBoxStatusAll.Click();
        public void CheckboxStatusOpenSelect() => CheckboxStatusOpen.Click();
        public void CheckboxStatusOpenComingSelect() => CheckboxStatusComing.Click();

        //Searching for a Location
        public void SearchingForLocation(String locationAddress)
        {
            LocationsSearchBar.SendKeys(locationAddress);
            Thread.Sleep(1000);
            SearchButton.Click();
        }



    }
}
