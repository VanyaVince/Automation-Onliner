using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckflowOnliner.Pages
{
    class CartPage : BasePage
    {
        private ReadOnlyCollection<IWebElement> ProductTitels => WebDriver.FindElements(By.XPath("//div[contains(@class,'image')]/following-sibling::div//a[not(contains(@class,'button'))]"));

        private IWebElement _productContainer;

        public CartPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        private void ProductContainer(string value)
        {
            _productContainer = WebDriver.FindElement(By.XPath($"//a[contains(text(), '{value}')]//ancestor::div[contains(@class,'unit')]"));
        }

        public void DeleteProduct(string value)
        {
            string deleteBtnLocator = "//a[contains(@class,'remove')]";
            ProductContainer(value);
            IWebElement product = _productContainer.FindElement(By.XPath(deleteBtnLocator));
            Actions actions = new Actions(WebDriver);
            actions.MoveToElement(product).Click().Perform();
            product.Click();
        }

        public bool IsProductContainerDisplayed(string value)
        {
            return _productContainer.Displayed;
        }
    }
}
