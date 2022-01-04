using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpeckflowOnliner.Pages
{
    class CalculatorPage : BasePage
    {
        private const string CalculatorUrl = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

        public const int DefaultWaitInSeconds = 5;

        public CalculatorPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        private IWebElement FirstNumberElement => WebDriver.FindElement(By.Id("first-number"));
        private IWebElement SecondNumberElement => WebDriver.FindElement(By.Id("second-number"));
        private IWebElement AddButtonElement => WebDriver.FindElement(By.Id("add-button"));
        private IWebElement ResultElement => WebDriver.FindElement(By.Id("result"));
        private IWebElement ResetButtonElement => WebDriver.FindElement(By.Id("reset-button"));

        public void Open()
        {
            WebDriver.Navigate().GoToUrl(CalculatorUrl);
        }
        public void EnterFirstNumber(string number)
        {
            FirstNumberElement.Clear();
            FirstNumberElement.SendKeys(number);
        }

        public void EnterSecondNumber(string number)
        {
            SecondNumberElement.Clear();
            SecondNumberElement.SendKeys(number);
        }

        public void ClickAdd()
        {
            AddButtonElement.Click();
        }

        public void EnsureCalculatorIsOpenAndReset()
        {
            if (WebDriver.Url != CalculatorUrl)
            {
                WebDriver.Url = CalculatorUrl;
            }
            else
            {
                ResetButtonElement.Click();

                WaitForEmptyResult();
            }
        }

        public string WaitForNonEmptyResult()
        {
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => !string.IsNullOrEmpty(result));
        }

        public string WaitForEmptyResult()
        {
            return WaitUntil(
                () => ResultElement.GetAttribute("value"),
                result => result == string.Empty);
        }

        /// <summary>
        /// Helper method to wait until the expected result is available on the UI
        /// </summary>
        /// <typeparam name="T">The type of result to retrieve</typeparam>
        /// <param name="getResult">The function to poll the result from the UI</param>
        /// <param name="isResultAccepted">The function to decide if the polled result is accepted</param>
        /// <returns>An accepted result returned from the UI. If the UI does not return an accepted result within the timeout an exception is thrown.</returns>
        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            });
        }
    }
}
