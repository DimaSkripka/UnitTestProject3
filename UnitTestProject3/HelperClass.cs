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
using System.Linq;
using System.IO;


namespace UnitTestProject3
{
    public class HelperClass
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        Random rnd = new Random();

        public HelperClass(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }
        public IList<IWebElement> SelectRandomItems(IList<IWebElement> itemList)
        {
            
            IList<IWebElement> selectedProducts = new List<IWebElement>();


            while (selectedProducts.Count != 2)
            {
                int rndValue = rnd.Next(0, itemList.Count());
                var x = itemList[rndValue];

                if (!selectedProducts.Contains(itemList[rndValue]))
                {
                    selectedProducts.Add(itemList[rndValue]);
                    x.FindElement(By.ClassName("add-to-cart-button")).Click();
                }
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    int rndValue = rnd.Next(0, itemList.Count());
            //    var x = itemList[rndValue];

            //    if (!selectedProducts.Contains(itemList[rndValue]))
            //    {
            //        selectedProducts.Add(itemList[rndValue]);
            //        x.FindElement(By.ClassName("add-to-cart-button")).Click();
            //    }
               
            //}

            return selectedProducts;
        }

        public List<Product> getProductAttributes(IList<IWebElement> selectedProducts, string nameLocator, string descriptionLocator, string priceLocator)
        {
            IList<IWebElement> test = new List<IWebElement>(selectedProducts);

            List<Product> productsWithAttributes = new List<Product>();

            for (int i = 0; i < test.Count; i++)
            {
                Product product = new Product();
                product.name = test[i].FindElement(By.ClassName(nameLocator)).Text;
                product.price = test[i].FindElement(By.ClassName(priceLocator)).Text;
                product.description = test[i].FindElement(By.ClassName(descriptionLocator)).Text;
                productsWithAttributes.Add(product);
                
            }

            //foreach (var item in test)
            //{
            //    Product product = new Product();
            //    product.name = item.FindElement(By.ClassName(nameLocator)).Text;
            //    product.price = item.FindElement(By.ClassName(priceLocator)).Text;
            //    product.description = item.FindElement(By.ClassName(descriptionLocator)).Text;
            //    productsWithAttributes.Add(product);
            //}
            return productsWithAttributes;
        }

        public bool isAdedProductCountMatch(IList<IWebElement> addedProducts)
        {

            int productCount = Int32.Parse(driver.FindElement(By.ClassName("fa-layers-counter")).Text);
            if (productCount == addedProducts.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<float> getPriceInt(List<Product> attributes)
        {
            List<float> prices = new List<float>();
            foreach (var item in attributes)
            {
                string x = item.price.ToString().Remove(0, 1);
                //string y = x.Remove(x.Length, 1);
                float z = float.Parse(x);
                prices.Add(z);
            }
            return prices;
        }

        public bool isMatchWithTotal(List<float> productPrices, IWebElement totalPrice)
        {

            float productsPrice = productPrices.Sum();
            string test = totalPrice.Text.Remove(0, 13);
            float total = float.Parse(test);

            
            if (productsPrice == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}