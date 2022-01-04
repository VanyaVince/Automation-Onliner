using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckflowOnliner.Pages
{
    internal class ProductPage: BasePage
    {
        public ProductPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        private IWebElement ProductBookmark => WebDriver.FindElement(By.XPath("//li[@id='product-bookmark-control']//span[@class='i-checkbox__faux']"));
        private IWebElement PersonalBookmarks => WebDriver.FindElement(By.XPath("//a[contains(@class,'favorites')]"));
        private IWebElement ProductTitle => WebDriver.FindElement(By.XPath("//div[@class='catalog-masthead']//h1"));
        private IWebElement AddProductBtnToCart => WebDriver.FindElement(By.XPath("//div[@class='product-aside__box']/a[not(contains(@href,'?'))]"));

        public void AddProductToFavoriteList()
        {
            ProductBookmark.Click();
        }

        public void ProccedToPersonalBookmarks()
        {
            PersonalBookmarks.Click(); 
        }

        public String GetProductTitle()
        {
            return ProductTitle.Text;
        }

        public void AddProductCart()
        {
            AddProductBtnToCart.Click();
        }
    }
}
