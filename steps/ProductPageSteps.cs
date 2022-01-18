using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onliner.Pages;
using OpenQA.Selenium;

namespace Onliner.steps
{
    public class ProductPageSteps
    {
        private readonly ProductPage _productPage;

        public ProductPageSteps(IWebDriver driver)
        {
            _productPage = new ProductPage(driver);
        }

        public string GetProductId()
        {
            return _productPage.GetProductImageSource();
        }

        public void AddProductToFavoriteList()
        {
            _productPage.ClickOnProductBookmarkBtn();
        }

        public void ProccedToPersonalBookmarks()
        {
            _productPage.ClickOnPersonalBookmarks();
        }

        public void AddProductCart()
        {
            _productPage.ClickOnAddProductCartBtn();
        }
    }
}
