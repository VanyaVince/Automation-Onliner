using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Onliner.Drivers
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
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--host-resolver-rules=MAP www.google-analytics.com 127.0.0.1");

            IWebDriver driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }

        public static WebDriverWait CreateWebDriverWait(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait;
        }
    }
}