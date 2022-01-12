using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Onliner.Pages
{
    internal class ProductPage: BasePage
    {
        public ProductPage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement ProductBookmark => webDriver.FindElement(By.XPath("//li[@id='product-bookmark-control']//span[@class='i-checkbox__faux']"));
        private IWebElement PersonalBookmarks => webDriver.FindElement(By.XPath("//a[contains(@class,'favorites')]"));
        private IWebElement ProductImage => webDriver.FindElement(By.XPath("//img[@id='device-header-image']"));
        private IWebElement AddProductBtnToCart => webDriver.FindElement(By.XPath("//div[@class='product-aside__box']/a[not(contains(@href,'?'))]"));
        
        public void SelectFilter(string value)
        {
        }
        
        public void AddProductToFavoriteList()
        {
            ProductBookmark.Click();
        }

        public void ProccedToPersonalBookmarks()
        {
            PersonalBookmarks.Click(); 
        }

        public string GetProductId()
        {
            return ProductImage.GetAttribute("src").Remove(0, 6);
        }

        public void AddProductCart()
        {
            AddProductBtnToCart.Click();
        }
    }
}
