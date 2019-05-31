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

        [FindsBy(How = How.Id, Using = "first-name")]//XPath, Using = "//*[@id='checkout_info_container']/div/form/input[1]")]
        public IWebElement firstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]//XPath, Using = "//*[@id='checkout_info_container']/div/form/input[2]")]
        public IWebElement lastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]//XPath, Using = "//*[@id='checkout_info_container']/div/form/input[3]")]
        public IWebElement zipCode { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_primary")]
        public IWebElement continueButton { get; set; }
    }
}
