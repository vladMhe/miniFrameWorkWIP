using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace t3.Pages
{
    class WPEditSiteMenuPage:DriverHelper
    {
    /*Selectors*/
        IWebElement acceptCookie => Driver.FindElement(By.XPath("//input[@value=\"Close and accept\"]"));
        IWebElement siteIdentifyButton => Driver.FindElement(By.XPath("//h3[contains(text(), 'Site Identity')]"));
        IWebElement selectLogoButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Select logo')]"));
        IWebElement uploadFilesTab => Driver.FindElement(By.XPath("//button[contains(text(), 'Upload files')]"));
        IWebElement selectFilesButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Select Files')]"));
        IWebElement selectUploadedImageButton => Driver.FindElement(By.XPath("//div[@class=\"media-toolbar-primary search-form\"]/button"));
        IWebElement cropImageButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Crop image')]"));
        IWebElement customImage => Driver.FindElement(By.XPath("//div[@class=\"imgareaselect-selection\"]"));
        IWebElement customLogo => Driver.FindElement(By.XPath("//a[@class=\"custom-logo-link\"]/img"));
        IWebElement saveButton => Driver.FindElement(By.XPath("//input[@id=\"save\"]"));
        IWebElement inputFile => Driver.FindElement(By.XPath("//input[starts-with(@id, 'html5_')]"));
        //IWebElement checkImage => Driver.FindElement(By.XPath("//img[contains(@src, '')]"));

        public IWebElement SiteIdentifyButton { get { return siteIdentifyButton; } }
        public IWebElement AcceptCookie { get { return acceptCookie; } }
        public IWebElement SelectLogoButton { get { return selectLogoButton; } }
        public IWebElement SelectFilesButton { get { return selectFilesButton; } }
        public IWebElement SelectUploadedImageButton { get { return selectUploadedImageButton; } }
        public IWebElement CropImageButton { get { return cropImageButton; } }
        public IWebElement CustomImage { get { return customImage; } }
        public IWebElement CustomLogo { get { return customLogo; } }
        public IWebElement SaveButton { get { return saveButton; } }
        public IWebElement InputFile { get { return inputFile; } }


        /*Actions*/
        public void ChangeToFileTab()
        {
            try
            {
                uploadFilesTab.Click();
            }
            catch (ElementNotInteractableException)
            {
                Console.WriteLine("No tab here");
            }
        }

        //Upload an image after opening browser dialog select
        //public void UploadImage(string imageLocation)
        //{
        //    AutoItX3 openDialog = new AutoItX3();
        //    openDialog.WinActivate("File Upload");
        //    Thread.Sleep(2000);
        //    openDialog.Send(imageLocation);
        //    Thread.Sleep(2000);
        //    openDialog.Send("{ENTER}");
        //}

        //Moves image while in Crop Mode //righ offset/up offset

        public void UploadImage()
        {
            inputFile.SendKeys(@"C:\a1\t3\TestData\patrik.jpg");
        }

        public void DragImage(int right, int up)
        {
            Actions crop = new Actions(Driver);
            crop.ClickAndHold(CustomImage).MoveByOffset(right, up).Release().Build().Perform();

        }
    }
}
