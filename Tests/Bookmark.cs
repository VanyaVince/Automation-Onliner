using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using Onliner.steps;
using System;

namespace Onliner.Tests
{
    public class Bookmark : BaseTest
    {
        private readonly string _product = "Телевизоры";

        private string? _expectedProductId;

        [SetUp]
        public void SetUp()
        {
            driver = new Driver();
            homePageSteps = new HomePageSteps(driver.CurrentDriver);
            loginPageSteps = new LoginPageSteps(driver.CurrentDriver);
            productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
            productPageSteps = new ProductPageSteps(driver.CurrentDriver);
            bookmarkPageSteps = new BookmarkPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void MarkProductAsFavorite()
        {
            homePageSteps.OpenUrl(url);
            loginPageSteps.Login(NicknameValue, PasswordValue);

            homePageSteps.SearchForProduct(_product);
            productListeningPageSteps.SelectProductFromGrid(0);

            _expectedProductId = productPageSteps.GetProductId();

            productPageSteps.AddProductToFavoriteList();
            productPageSteps.ProccedToPersonalBookmarks();

            Assert.IsTrue(bookmarkPageSteps.IsProductDisplayed(_expectedProductId));
        }

        [TearDown]
        public override void TearDown()
        {
            bookmarkPageSteps.RemoveAllProduct();
            driver.CurrentDriver.Quit();
        }
    }
}