using Onliner.Drivers;
using OpenQA.Selenium;
using System;

namespace Onliner.Pages
{
    class CartPage : BasePage
    {

        public CartPage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement FindProductContainer(string productId)
        {
            return webDriver.FindElement(By.XPath($"//img[@src='{productId}']//ancestor::div[contains(@class,'unit')]"));
        }

        public void DeleteProduct(string id)
        {
            string deleteBtnLocator = "//a[contains(@class,'remove')]";
            var removeBtn = FindProductContainer(id).FindElement(By.XPath(deleteBtnLocator));
            actions.MoveToElement(removeBtn).Perform();
            removeBtn.Click();
        }

        public void ClickOnIncrementQuantityBtn(string id)
        {
            string increaseQuantityBtnLocator = ".//a[contains(@class,'button_increment')]";
            string currentPrice = GetTotalProductPrice(id);

            FindProductContainer(id).FindElement(By.XPath(increaseQuantityBtnLocator)).Click();

            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                string newPrice = GetTotalProductPrice(id);
                return currentPrice != newPrice;
            });
        }

        public string GetProductQuantity(string id)
        {
            string productQuantityLocator = ".//input";
            return FindProductContainer(id).FindElement(By.XPath(productQuantityLocator)).GetAttribute("value");
        }

        public string GetProductPricePerOneItem(string id)
        {
            string pricePerOneItemLocator = ".//div[contains(@class,'hint')]//span";
            return FindProductContainer(id).FindElement(By.XPath(pricePerOneItemLocator)).Text;
        }

        public string GetTotalProductPrice(string id)
        {
            string priceLocator = ".//div[contains(@class,'price_specific')]//span";
            return FindProductContainer(id).FindElement(By.XPath(priceLocator)).Text;
        }

        public bool IsProductRemoved(string id)
        {
            string name = "//div[contains(@class,'offers-part_vertical_middle')]";
            return FindProductContainer(id).FindElement(By.XPath(name)).Displayed;
        }
    }
}
