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

            try
            {
                Assert.IsTrue(helper.isAdedProductCountMatch(selectedProducts));
            }
            catch (Exception)
            {
                var writer = new StreamWriter(@"C:/TestData/TestDescription2.txt");
                writer.WriteLine("Cart Product Counter is not working correctly");
                writer.Flush();
                writer.Dispose();
                throw;
            }


            List<Product> productsWithAttributes1 = helper.getProductAttributes(selectedProducts, "inventory_item_name", "inventory_item_desc", "inventory_item_price");
            driver.FindElement(By.Id("shopping_cart_container")).Click();


            CartPage cart = new CartPage(this.driver);
            List<Product> productsWithAttributes2 = helper.getProductAttributes(cart.CartProducts(), "inventory_item_name", "inventory_item_desc", "inventory_item_price");
            /*не правильно работают сравнения*/


                try
                {
                    productsWithAttributes1.All(f => productsWithAttributes2.Any(g => g.name == f.name && g.price == f.price));
                    new CartPage(this.driver).checkOutButton.Click();
                }
                catch (Exception ex)
                {
                    var writer = new StreamWriter(@"C:/Users/skripka/Desktop/TestData/TestDescription4.txt");
                    writer.WriteLine("not match");
                    writer.Flush();
                    writer.Dispose();
                    new CartPage(this.driver).checkOutButton.Click();
                }
            

            

            CheckOutInformation checkInfo = new CheckOutInformation(this.driver);
            checkInfo.firstName.SendKeys("John");
            checkInfo.lastName.SendKeys("Konor");
            checkInfo.zipCode.SendKeys("12345");
            checkInfo.continueButton.Click();

            List<Product> cartProductsWithAttributes = helper.getProductAttributes(new CheckoutOverview(this.driver).OverviewProducts(), "inventory_item_name", "inventory_item_desc", "inventory_item_price");

            List<float> productPrices = helper.getPriceInt(cartProductsWithAttributes);

            /*не правильно работают сравнения*/
            //if (helper.isMatchWithTotal(productPrices, new CheckoutOverview(this.driver).totalPrice))
            //{
                try
            {
                productsWithAttributes2.All(f => cartProductsWithAttributes.Any(g => g.name == f.name && g.price == f.price));
                new CheckoutOverview(this.driver).finishButton.Click();
            }
            catch (Exception ex)
            {

                var writer = new StreamWriter(@"C:/TestData/TestDescription4.txt");
                writer.WriteLine("not match");
                writer.Flush();
                writer.Dispose();
                new CheckoutOverview(this.driver).finishButton.Click();
            }
            //}

            
        }
    }
}
