using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using t3.Pages;

namespace t3.Tests
{
    class ModMenuTests:DriverHelper
    {
        DriverHelper helper = new DriverHelper();
        ModMenuPage menu = new ModMenuPage();

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
        public void NavigatingThroughMenus()
        {
            //Pizza Menu
            menu.MenuCategoryySelect();
            helper.AssertByElementText("INDIVIDUAL, ARTISAN-STYLE PIZZAS, SALADS AND MORE", menu.MenuParagrahp);
            menu.Pizzas.Click();
            helper.AssertByElementText("GET A MOD 11-INCH CLASSIC OR CREATE YOUR OWN", menu.PizzaParagraph);
            menu.PizzaIngredients.Click();
            helper.AssertByElementText("TOPPINGS", menu.TopicsTitle);

            //Salad Menu
            menu.MenuCategoryySelect();
            helper.AssertByElementText("INDIVIDUAL, ARTISAN-STYLE PIZZAS, SALADS AND MORE", menu.MenuParagrahp);
            menu.Salads.Click();
            helper.AssertByElementText("GET A CLASSIC OR CREATE YOUR OWN", menu.SaladsParagraph);
            menu.SaladsIngredients.Click();
            helper.AssertByElementText("TOPPINGS", menu.TopicsTitle);

            //Sides Menu
            menu.MenuCategoryySelect();
            helper.AssertByElementText("INDIVIDUAL, ARTISAN-STYLE PIZZAS, SALADS AND MORE", menu.MenuParagrahp);
            menu.Sides.Click();
            helper.AssertByElementText("SIDES & GOOD STUFF", menu.SidesTitle);

            //Beverages
            menu.MenuCategoryySelect();
            helper.AssertByElementText("INDIVIDUAL, ARTISAN-STYLE PIZZAS, SALADS AND MORE", menu.MenuParagrahp);
            menu.Beverages.Click();
            helper.AssertByElementText("FOUNTAIN DRINKS", menu.BeveragesParagraph);

        }

    }
}
