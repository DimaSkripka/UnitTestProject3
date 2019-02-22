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
    class CheckOutInformation
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public CheckOutInformation(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='checkout_info_container']/div/form/input[1]")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='checkout_info_container']/div/form/input[2]")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='checkout_info_container']/div/form/input[3]")]
        public IWebElement zipCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "cart_checkout_link")]
        public IWebElement continueButton { get; set; }
    }
}
