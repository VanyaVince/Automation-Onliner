using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using Onliner.steps;
using System.Collections.Generic;
using System.Linq;


namespace Onliner.Tests
{
    public class Filter : BaseTest
    {
        private readonly string _product = "Мобильные телефоны";
        private readonly string _producer = "Производитель";

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
            homePageSteps.SearchForProduct(_product);

            productListeningPageSteps.SelectRandomFilterFromSection(_producer);

            List<string> productTitles = productListeningPageSteps.GetAllProductsTitlesDisplayed();

            Assert.IsTrue(productTitles.All(title => title.Contains(productListeningPageSteps.GetSelectedFilter())));
        }
    }
}
