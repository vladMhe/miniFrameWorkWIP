using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace t3.Pages
{
    class WPSettingsPage:DriverHelper
    {
        IWebElement settingsTitle => Driver.FindElement(By.XPath("//h1[contains(text(),'Settings')]"));
        IWebElement titleField => Driver.FindElement(By.XPath("//input[@type=\"text\"]"));
        IWebElement descriptionField => Driver.FindElement(By.XPath("//input[@name=\"blogdescription\"]"));
        IWebElement languagePickButton => Driver.FindElement(By.XPath("//button[contains(@class, 'language-picker')]/div[2]"));
        IWebElement selectLanguageTitle => Driver.FindElement(By.XPath("//div[contains(text(), 'Select a language')]"));
        IWebElement saveSettingsButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Save settings')]"));
        IWebElement saveAlert => Driver.FindElement(By.XPath("//span[contains(text(), 'Settings saved successfully!')]"));
        IWebElement languageApplyButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Apply Changes')]"));
        IWebElement timeZone => Driver.FindElement(By.XPath("//*[@class=\"form-select\"]"));


        public IWebElement SettingsTitle { get { return settingsTitle; } }
        public IWebElement TitleField { get { return titleField; } }
        public IWebElement DescriptionField { get { return descriptionField; } }
        public IWebElement LanguagePickButton { get { return languagePickButton; } }
        public IWebElement LanguageApplyButton { get { return languageApplyButton; } }
        public IWebElement SelectLanguageTitle { get { return selectLanguageTitle; } }
        public IWebElement SaveSettingsButton { get { return saveSettingsButton; } }
        public IWebElement SaveAlert { get { return saveAlert; } }
        public IWebElement TimeZone { get { return timeZone; } }


        public void SiteNameAndDescription(String title, String description)
        {
            WaitElement(TitleField);
            TitleField.SendKeys(Keys.Control + "a"+ Keys.Delete);
            TitleField.SendKeys(title);
            DescriptionField.SendKeys(Keys.Control + "a" + Keys.Delete);
            DescriptionField.SendKeys(description);
        }

        //Selects Specfic language from a Specific Region
        public void SelectLanguageFAux(String region, String language)
        {
            languagePickButton.Click();
            IWebElement regionChoose = Driver.FindElement(By.XPath($"//span[contains(text(), '{region}')]"));
            regionChoose.Click();
            IWebElement languageChoose = Driver.FindElement(By.XPath($"//button[contains(@title, '{language}')]"));
            languageChoose.Click();
            LanguageApplyButton.Click();
        }

        //Select Site Timezone
        public void SelectTimeZone(String timeZone)
        {
            var selectElement = new SelectElement(TimeZone);
            selectElement.SelectByText(timeZone);
        }


    }
}
