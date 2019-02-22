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
    public class Exceptions
    {
        private readonly IWebDriver driver;
        public WebDriverWait wait;

        Random rnd = new Random();

        public Exceptions(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void CheckIsElementPresented(string elementLocator, string exceptionText, string txtPath)
        {
            StreamWriter writer = new StreamWriter(txtPath);
            try
            {
                driver.FindElement(By.ClassName(elementLocator));
            }
            catch (Exception ex)
            {
                writer.WriteLine(exceptionText);
            }
        }
    }
}