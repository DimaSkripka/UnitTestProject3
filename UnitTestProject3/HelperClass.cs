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

            int rndValue = rnd.Next(0, itemList.Count());

            for (int i = 0; i < 1; i++)
            {
                var x = itemList[rndValue];
                selectedProducts.Add(x);
                x.FindElement(By.ClassName("add-to-cart-button")).Click();
            }

            //itemList[rndValue].FindElement(By.ClassName("add-to-cart-button"));
            return selectedProducts;
        }

        public List<Product> getProductAttributes(IList<IWebElement> selectedProducts, string nameLocator, string descriptionLocator, string priceLocator)
        {

            List<Product> productsWithAttributes = new List<Product>();

            //ProductsPage products = new ProductsPage(this.driver);
            foreach (var item in selectedProducts)
            {
                Product product = new Product();
                product.name = item.FindElement(By.ClassName(/*"inventory_item_name"*/nameLocator)).GetAttribute("innerText");
                product.price = item.FindElement(By.ClassName(/*"inventory_item_price"*/priceLocator)).GetAttribute("innerText");
                product.description = item.FindElement(By.ClassName(/*"inventory_item_desc"*/descriptionLocator)).GetAttribute("innerText");
                productsWithAttributes.Add(product);
            }
            return productsWithAttributes;
        }
    }
}