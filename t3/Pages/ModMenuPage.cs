using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace t3.Pages
{
    class ModMenuPage:DriverHelper
    {
        /*Selectors*/
        IWebElement menuCategory => Driver.FindElement(By.XPath("//a[@href=\"https://modpizza.com/menu/\"]"));
        IWebElement menuParagrahp => Driver.FindElement(By.XPath("//*[contains(text(),'Individual, artisan-style pizzas, salads and more')]"));
        IWebElement pizzas => Driver.FindElement(By.XPath("//a[@href=\"#pizzas\"]"));
        IWebElement pizzaParagraph => Driver.FindElement(By.XPath("//*[contains(text(),'Get a MOD 11-inch Classic or create your own')]"));
        IWebElement pizzaIngredients => Driver.FindElement(By.XPath("//*[contains(text(),'Ingredients')]"));
        IWebElement salads => Driver.FindElement(By.XPath("//a[@href=\"#salads\"]"));
        IWebElement saladsParagraph => Driver.FindElement(By.XPath("//*[contains(text(),'Get a Classic or Create Your Own')]"));
        IWebElement saladsIngredients => Driver.FindElement(By.XPath("//*[contains(text(), 'Start with romaine or mixed greens')]/following-sibling::a"));
        IWebElement topicsTitle => Driver.FindElement(By.XPath("//*[contains(text(),'Toppings')]"));
        IWebElement sides => Driver.FindElement(By.XPath("//a[@href=\"#sides\"]"));
        IWebElement sidesTitle => Driver.FindElement(By.XPath("//*[contains(text(),'Sides & Good Stuff')]"));
        IWebElement beverages => Driver.FindElement(By.XPath("//a[@href=\"#beverages\"]"));
        IWebElement beveragesParagraph => Driver.FindElement(By.XPath("//*[contains(text(),'Fountain Drinks')]"));


        public IWebElement MenuCategory { get { return menuCategory; } }
        public IWebElement MenuParagrahp { get { return menuParagrahp; } }
        public IWebElement Pizzas { get { return pizzas; } }
        public IWebElement PizzaParagraph { get { return pizzaParagraph; } }
        public IWebElement PizzaIngredients { get { return pizzaIngredients; } }
        public IWebElement TopicsTitle { get { return topicsTitle; } }
        public IWebElement Salads { get { return salads; } }
        public IWebElement SaladsParagraph { get { return saladsParagraph; } }
        public IWebElement SaladsIngredients { get { return saladsIngredients; } }
        public IWebElement Sides { get { return sides; } }
        public IWebElement SidesTitle { get { return sidesTitle; } }
        public IWebElement Beverages { get { return beverages; } }
        public IWebElement BeveragesParagraph { get { return beveragesParagraph; } }




        /*Actions*/
        public void MenuCategoryySelect() => MenuCategory.Click();

    }
}
