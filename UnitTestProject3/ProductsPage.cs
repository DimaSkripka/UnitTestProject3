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

namespace UnitTestProject3
{
    class ProductsPage
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public ProductsPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "inventory_list")]
        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        public IList<IWebElement> ProductList { get; set; }
    }
}