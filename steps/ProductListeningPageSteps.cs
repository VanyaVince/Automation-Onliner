using Onliner.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.steps
{
    public class ProductListeningPageSteps
    {
        private readonly IWebDriver _driver;
        private readonly ProductListeningPage _productListeningPage;
        private readonly Random _random = new Random();

        public ProductListeningPageSteps(IWebDriver driver)
        {
            _driver = driver;
            _productListeningPage = new ProductListeningPage(driver);
        }

        public void SelectRandomFilterFromSection(string filterName)
        {   
            var randomNumber = _random.Next(_productListeningPage.FindAllFiltersFromSection(filterName).Count);
            _productListeningPage.SelectFilterByIndexFromSection(filterName, randomNumber);
        }

        public List<string> GetAllProductsTitlesDisplayed()
        {
            List<string> products = new List<string>();

            while (!_productListeningPage.IsLastPage())
            {
                _productListeningPage.GetProductTitels(products);
                _productListeningPage.ProceedToNextProductPage();

            }
            _productListeningPage.GetProductTitels(products);

            Console.WriteLine($"numbers of product collected {products.Count}");
            return products;
        }

        public string GetSelectedFilter()
        {
            return _productListeningPage.GetSelectedFilter();
        }
    }
}
