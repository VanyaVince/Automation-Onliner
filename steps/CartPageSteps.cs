using Onliner.Pages;
using Onliner.Utils;
using OpenQA.Selenium;
using System;


namespace Onliner.steps
{
    public class CartPageSteps
    {
        private readonly CartPage _cartPage; 

        public CartPageSteps(IWebDriver driver)
        {
            _cartPage = new CartPage(driver);
        }

        public void IncreaseProductQuantity(string productId)
        {
            _cartPage.ClickOnIncrementQuantityBtn(productId);
        }

        public bool IsProductRemoved(string id)
        {
            return _cartPage.IsProductRemoved(id);
        }

        public void DeleteProduct(string id)
        {
            _cartPage.ClickOnDeleteProductBtn(id);
        }

        public bool IsProductPriceCalculatedProperly(string id)
        {
            var pricePerItem = ServiceHelper.ConvertPriceToDouble(_cartPage.GetProductPricePerOneItem(id));
            var productQuantity = Int32.Parse(_cartPage.GetProductQuantity(id));
            var totalPrice = ServiceHelper.ConvertPriceToDouble(_cartPage.GetTotalProductPrice(id));

            return pricePerItem * productQuantity == totalPrice;
        }
        
    }
}
