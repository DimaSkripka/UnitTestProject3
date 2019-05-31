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
    class LoginPage
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        public LoginPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement UserPasswordField { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn_action")]
        public IWebElement LoginButton { get; set; }


    }
}
