using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Pages
{
    class PreviewCartPage : BasePage
    {
        public PreviewCartPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        private IWebElement ProceedToCartBtn => WebDriver.FindElement(By.XPath("//div[contains(@class,'control_checkout')]/a[contains(@href,'cart')]"));

        public void ProceedToCart()
        {
            ProceedToCartBtn.Click();
        }
    }
}
