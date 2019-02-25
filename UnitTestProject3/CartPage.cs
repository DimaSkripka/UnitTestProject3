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
using System.Linq;

namespace UnitTestProject3
{
    class CartPage
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public CartPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        //[FindsBy(How = How.ClassName, Using = "cart_list")]
        //[FindsBy(How = How.ClassName, Using = "cart_item")]
        public IList<IWebElement> CartProducts()
        {
            IList<IWebElement> test = driver.FindElement(By.ClassName("cart_list")).FindElements(By.ClassName("cart_item"));
            return test;
        }


        [FindsBy(How = How.ClassName, Using = "cart_checkout_link")]
        public IWebElement checkOutButton { get; set; }
    }
}
////*[@id="cart_contents_container"]/div/div[1]/div[3]\

