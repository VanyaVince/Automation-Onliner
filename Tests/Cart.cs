using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using Onliner.steps;
using System;
using System.Threading;

namespace Onliner.Tests
{
    public class Cart : BaseTest
    {
        private readonly string _product = "Мобильные телефоны";
        private string? _productId;

        [SetUp]
        public void SetUp()
        {
            driver = new Driver();
            homePageSteps = new HomePageSteps(driver.CurrentDriver);
            loginPageSteps = new LoginPageSteps(driver.CurrentDriver);
            productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
            productPageSteps = new ProductPageSteps(driver.CurrentDriver);
            previewCartPageSteps = new PreviewCartPageSteps(driver.CurrentDriver);
            cartPageSteps = new CartPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void DeleteProductFromCart()
        {
            homePageSteps.OpenUrl(url);
            homePageSteps.SearchForProduct(_product);
            productListeningPageSteps.SelectProductFromGrid(0);
            _productId = productPageSteps.GetProductId();
            productPageSteps.AddProductCart();
            previewCartPageSteps.ProceedToCart();
            cartPageSteps.DeleteProduct(_productId);

            Assert.IsTrue(cartPageSteps.IsProductRemoved(_productId));
        }

        [Test]
        public void IncreaseProductQuantity()
        {
            homePageSteps.OpenUrl(url);
            homePageSteps.SearchForProduct(_product);
            productListeningPageSteps.SelectProductFromGrid(0);
            _productId = productPageSteps.GetProductId();
            productPageSteps.AddProductCart();
            previewCartPageSteps.ProceedToCart();
            cartPageSteps.IncreaseProductQuantity(_productId);

            Assert.IsTrue(cartPageSteps.IsProductPriceCalculatedProperly(_productId));

            cartPageSteps.DeleteProduct(_productId);

        }
    }
}
