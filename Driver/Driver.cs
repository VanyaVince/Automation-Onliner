using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SpeckflowOnliner.Drivers
{
    public class Driver
    {
        private readonly IWebDriver _currentWebDriver;

        public Driver()
        {
            _currentWebDriver = GetDriver();
        }

        public IWebDriver CurrentDriver => _currentWebDriver;


        private IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        public static WebDriverWait CreateWebDriverWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }
    }
}