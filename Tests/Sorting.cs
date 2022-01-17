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
    class Sorting
    {
        private readonly Driver driver = new Driver();
        private readonly string _productName = "Планшеты";
        private readonly string _sortingType = "Дорогие";

        private readonly HomePage _homePage;
        private readonly PreviewResultPage _previewResultPage;
        private readonly ProductListeningPageSteps _productListeningPageSteps;

        public Sorting()
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _previewResultPage = new PreviewResultPage(driver.CurrentDriver);
            _productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void FilterProductWithSpecificProducer()
        {
            _homePage.OpenUrl();
            _homePage.SearchProduct(_productName);
            _previewResultPage.SelectProduct(_productName);

            _productListeningPageSteps.SelectSorting(_sortingType);

            Assert.IsTrue(_productListeningPageSteps.isSortedBy(_sortingType));
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Quit();
        }

    }
}
