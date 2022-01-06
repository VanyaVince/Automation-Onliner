using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Pages
{
    internal class ProductPage: BasePage
    {
        public ProductPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        private IWebElement ProductBookmark => WebDriver.FindElement(By.XPath("//li[@id='product-bookmark-control']//span[@class='i-checkbox__faux']"));
        private IWebElement PersonalBookmarks => WebDriver.FindElement(By.XPath("//a[contains(@class,'favorites')]"));
        private IWebElement ProductImage => WebDriver.FindElement(By.XPath("//img[@id='device-header-image']"));
        private IWebElement AddProductBtnToCart => WebDriver.FindElement(By.XPath("//div[@class='product-aside__box']/a[not(contains(@href,'?'))]"));

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
