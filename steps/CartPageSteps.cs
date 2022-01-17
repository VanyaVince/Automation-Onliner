using Onliner.Pages;
using Onliner.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.steps
{
    class CartPageSteps
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

        public bool IsProductPriceCalculatedProperly(string id)
        {
            var pricePerItem = ServiceHelper.ConvertPriceToDouble(_cartPage.GetProductPricePerOneItem(id));
            var productQuantity = Int32.Parse(_cartPage.GetProductQuantity(id));
            var totalPrice = ServiceHelper.ConvertPriceToDouble(_cartPage.GetTotalProductPrice(id));


            //Console.WriteLine($"calculated price of product by test is {pricePerItem * productQuantity}. Total price displayed on the screen is {totalPrice}");
            //Console.WriteLine($"product price of item equals {pricePerItem}/d product quantty dispalyed is {productQuantity}");
            return pricePerItem * productQuantity == totalPrice;
        }
        
    }
}
