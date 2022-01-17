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
    public class ProductListeningPageSteps
    {
        private readonly ProductListeningPage _productListeningPage;
        private readonly Random _random = new Random();
        private readonly Sorting _sortingHelper = new Sorting();

        public ProductListeningPageSteps(IWebDriver driver)
        {
            _productListeningPage = new ProductListeningPage(driver);
        }

        public void SelectRandomFilterFromSection(string filterName)
        {   
            var randomNumber = _random.Next(_productListeningPage.FindAllFiltersFromSection(filterName).Count);
            _productListeningPage.SelectFilterByIndexFromSection(filterName, randomNumber);
        }

        public List<string> GetAllProductsTitlesDisplayed()
        {
            List<string> productsTitles = new List<string>();

            while (!_productListeningPage.IsLastPage())
            {
                productsTitles.AddRange(_productListeningPage.GetProductTitels());
                _productListeningPage.ProceedToNextProductPage();

            }
            productsTitles.AddRange(_productListeningPage.GetProductTitels());
            
            Console.WriteLine($"number of products {productsTitles.Count}");
            return productsTitles;
        }

        public string GetSelectedFilter()
        {
            return _productListeningPage.GetSelectedFilter();
        }

        public void SelectSorting(string sortingName)
        {
            _productListeningPage.OpenSortingPanel();
            _productListeningPage.SelectSortingType(sortingName);
        }

        public bool isSortedBy(string sortingName)
        {
            var prices = _productListeningPage.GetProductPrices();
            return _sortingHelper.isSortedBy(sortingName, prices);
        }
    }
}
