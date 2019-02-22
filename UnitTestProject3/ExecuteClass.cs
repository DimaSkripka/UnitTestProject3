using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;


namespace UnitTestProject3
{
    [TestClass]
    public class ExecuteClass
    {

        public IWebDriver driver { get; set; }
        public WebDriverWait wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestScenario scenario = new TestScenario(this.driver);
            TestSetup setup = new TestSetup(this.driver);
            setup.Navigate();
            scenario.Login();
        }
    }
}
