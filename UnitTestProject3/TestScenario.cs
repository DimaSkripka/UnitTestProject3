using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestProject3
{
    class TestScenario
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public TestScenario(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void Login()
        {
            LoginPage loginpage = new LoginPage(this.driver);
            loginpage.UserNameField.Clear();
            loginpage.UserNameField.SendKeys("standard_user");

            loginpage.UserPasswordField.Clear();
            loginpage.UserPasswordField.SendKeys("secret_sauce");

            loginpage.LoginButton.Click();

            HelperClass helper = new HelperClass(this.driver);
            ProductsPage productsPage = new ProductsPage(this.driver);
            //helper.SetRandomItem(productsPage.ProductList);
            IList<IWebElement> selectedProducts = helper.SelectRandomItems(productsPage.ProductList);
            List<Product> productsWithAttributes1 = helper.getProductAttributes(selectedProducts, "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            driver.FindElement(By.Id("shopping_cart_container")).Click();

            CartPage cart = new CartPage(this.driver);
            List<Product> productsWithAttributes2 = helper.getProductAttributes(cart.ProductList, "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            if (productsWithAttributes1.All(f => productsWithAttributes2.Any(g => g.name == f.name && g.price == f.price)))
            {
                driver.FindElement(By.ClassName("cart_checkout_link")).Click();
            }

            //Assert.IsTrue(productsWithAttributes1.All(f => productsWithAttributes2.Any(g => g.name == f.name && g.price == f.price)));

        }

        public void Test()
        {
            HelperClass helper = new HelperClass(this.driver);
            
        }
    }
}
