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
    public class Sorting : BaseTest
    {
        private readonly string _productName = "Планшеты";
        private readonly string _sortingType = "Дорогие";

        [SetUp]
        public void Setup()
        {
            driver = new Driver();
            homePageSteps = new HomePageSteps(driver.CurrentDriver);
            loginPageSteps = new LoginPageSteps(driver.CurrentDriver);
            productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void FilterProductWithSpecificProducer()
        {
            homePageSteps.OpenUrl(url);
            homePageSteps.SearchForProduct(_productName);
            productListeningPageSteps.SelectSorting(_sortingType);

            Assert.IsTrue(productListeningPageSteps.isSortedBy(_sortingType));
            
        }
    }
}
