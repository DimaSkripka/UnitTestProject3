﻿using System.Threading;
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
            HelperClass helper = new HelperClass(this.driver);
            LoginPage loginpage = new LoginPage(this.driver);
            Exceptions exception = new Exceptions(this.driver);

            loginpage.UserNameField.Clear();
            loginpage.UserNameField.SendKeys("standard_user");

            loginpage.UserPasswordField.Clear();
            loginpage.UserPasswordField.SendKeys("secret_sauce");

            loginpage.LoginButton.Click();

            
            ProductsPage productsPage = new ProductsPage(this.driver);
            IList<IWebElement> selectedProducts = helper.SelectRandomItems(productsPage.ProductList);
            List<Product> productsWithAttributes1 = helper.getProductAttributes(selectedProducts, "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            driver.FindElement(By.Id("shopping_cart_container")).Click();

            CartPage cart = new CartPage(this.driver);
            List<Product> productsWithAttributes2 = helper.getProductAttributes(cart.ProductList, "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            try
            {
                Assert.IsTrue(productsWithAttributes1.All(f => productsWithAttributes2.Any(g => g.name == f.name && g.price == f.price)));
            }
            catch (Exception ex)
            {
                new StreamWriter(@"C:/Users/skripka/Desktop/TestData/TestDescription2.txt").WriteLine("not match");
                new CartPage(this.driver).checkOutButton.Click();
            }

            CheckOutInformation checkInfo= new CheckOutInformation(this.driver);
            checkInfo.firstName.SendKeys("John");
            checkInfo.lastName.SendKeys("Konor");
            checkInfo.zipCode.SendKeys("12345");
            checkInfo.continueButton.Click();

            List<Product> cartProductsWithAttributes = helper.getProductAttributes(new CheckoutOverview(this.driver).productList, "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            try
            {
                Assert.IsTrue(productsWithAttributes2.All(f => cartProductsWithAttributes.Any(g => g.name == f.name && g.price == f.price)));
            }
            catch (Exception ex)
            {

                new StreamWriter(@"C:/Users/skripka/Desktop/TestData/TestDescription3.txt").WriteLine("not match");
                new CheckoutOverview(this.driver).finishButton.Click();
            }
        }

        public void Test()
        {
            HelperClass helper = new HelperClass(this.driver);
            
        }
    }
}
