using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using Onliner.steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Onliner.Tests
{
    public class Filter : BaseTest
    {
        private readonly string _product = "Мобильные телефоны";
        private readonly string _producer = "Производитель";
        private string? _productId;

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly ProductListeningPage _productListeningPage;
        private readonly ProductListeningPageSteps _productListeningPageSteps;
        private readonly ProductPage _productPage;
        private readonly PreviewCartPage _previewCartPage;
        private readonly CartPage _cartPage;

        private readonly Driver driver = new Driver();

        public Filter()
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
            _previewResultPage = new PreviewResultPage(driver.CurrentDriver);
            _productListeningPage = new ProductListeningPage(driver.CurrentDriver);
            _productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
            _productPage = new ProductPage(driver.CurrentDriver);
            _previewCartPage = new PreviewCartPage(driver.CurrentDriver);
            _cartPage = new CartPage(driver.CurrentDriver);
        }

        [Test]
        public void FilterProductWithSpecificProducer()
        {
            _homePage.OpenUrl();
            _homePage.SearchProduct(_product);
            _previewResultPage.SelectProduct(_product);

            _productListeningPageSteps.SelectRandomFilterFromSection(_producer);

            List<string> productTitles = _productListeningPageSteps.GetAllProductsTitlesDisplayed();

            Assert.IsTrue(productTitles.All(title => title.Contains(_productListeningPageSteps.GetSelectedFilter())));
        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Quit();
        }
    }
}
