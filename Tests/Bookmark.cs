using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using System;

namespace Onliner.Tests
{
    public class Bookmark : BaseTest
    {
        private readonly string _product = "Телевизоры";
        private string? _expectedProductId;

        private readonly Driver _drivers;

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly ProductListeningPage _searchResultPage;
        private readonly ProductPage _productPage;
        private readonly BookmarkPage _bookmarkPage;

        public Bookmark()
        {
            _drivers = new Driver();
            _homePage = new HomePage(_drivers.CurrentDriver);
            _loginPage = new LoginPage(_drivers.CurrentDriver);
            _previewResultPage = new PreviewResultPage(_drivers.CurrentDriver);
            _searchResultPage = new ProductListeningPage(_drivers.CurrentDriver);
            _productPage = new ProductPage(_drivers.CurrentDriver);
            _bookmarkPage = new BookmarkPage(_drivers.CurrentDriver);
        }
        [Test]
        public void MarkProductAsFavorite()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname(NicknameValue);
            _loginPage.EnterPassword(PasswordValue);
            _loginPage.ClickOnSubmitBtn();
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);
            _searchResultPage.ClickOnFirstItem();
            _expectedProductId = _productPage.GetProductId();
            _productPage.AddProductToFavoriteList();
            _productPage.ProccedToPersonalBookmarks();

            Assert.IsTrue(_bookmarkPage.IsProductDisplayed(_expectedProductId));
        }

        [TearDown]
        public void TearDown()
        {
            _bookmarkPage.RemoveAllProduct();
            _drivers.CurrentDriver.Quit();
        }
    }
}