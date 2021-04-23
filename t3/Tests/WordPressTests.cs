using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using t3;
using t3.Pages;

namespace WordPressLogin 
{ 
    class WordPressTests
    {
        DriverHelper helper = new DriverHelper();
        WPLoginPage wpPage = new WPLoginPage();

        [SetUp]
        public void Setup()
        {
            helper.InitBrowser("Chrome");
        }

        [TearDown]
        public void TearDown()
        {
            helper.EndSession();
        }

        //Verifying All, Open and Coming Soon locations
        [Test]
        public void Tesst()
        {
            helper.NavigateTo("https://wordpress.com/");
            wpPage.LogInButtonSelect();
        }
    }
}
