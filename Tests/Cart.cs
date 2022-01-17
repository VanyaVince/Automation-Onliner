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

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly ProductListeningPage _searchResultPage;
        private readonly ProductPage _productPage;
        private readonly PreviewCartPage _previewCartPage;
        private readonly CartPage _cartPage;
        private readonly CartPageSteps _cartPageSteps;

        private readonly Driver driver = new Driver();

        public Cart()
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
            _previewResultPage = new PreviewResultPage(driver.CurrentDriver);
            _searchResultPage = new ProductListeningPage(driver.CurrentDriver);
            _productPage = new ProductPage(driver.CurrentDriver);
            _previewCartPage = new PreviewCartPage(driver.CurrentDriver);
            _cartPage = new CartPage(driver.CurrentDriver);
            _cartPageSteps = new CartPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void DeleteProductFromCart()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname(NicknameValue);
            _loginPage.EnterPassword(PasswordValue);
            _loginPage.ClickOnSubmitBtn();
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);
            _searchResultPage.ClickOnFirstItemInProductGrid();
            _productId = _productPage.GetProductId();
            _productPage.AddProductCart();
            _previewCartPage.ProceedToCart();
            _cartPage.DeleteProduct(_productId);

            Assert.IsTrue(_cartPage.IsProductRemoved(_productId));
        }

        [Test]
        public void IncreaseProductQuantity()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname(NicknameValue);
            _loginPage.EnterPassword(PasswordValue);
            _loginPage.ClickOnSubmitBtn();
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);
            _searchResultPage.ClickOnFirstItemInProductGrid();

            _productId = _productPage.GetProductId();

            _productPage.AddProductCart();
            _previewCartPage.ProceedToCart();

            _cartPageSteps.IncreaseProductQuantity(_productId);

            Assert.IsTrue(_cartPageSteps.IsProductPriceCalculatedProperly(_productId));

            _cartPage.DeleteProduct(_productId);

        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Quit();
        }
    }
}
