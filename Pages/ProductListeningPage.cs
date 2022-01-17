using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support;
using Onliner.Drivers;
using OpenQA.Selenium;
using NUnit.Framework;
using Onliner.Utils;

namespace Onliner.Pages
{
    public class ProductListeningPage: BasePage
    {
        public ProductListeningPage(IWebDriver driver)
            : base(driver){}

        private ReadOnlyCollection<IWebElement> ProductsGrid => webDriver.FindElements(By.XPath("//div[@class='schema-product__group']//div[contains(@class,'part_1')]//a[contains(@data-bind,'product.html')]"));
        private ReadOnlyCollection<IWebElement> ProductsTitels => webDriver.FindElements(By.XPath("//span[contains(@data-bind,'product.full_name')]"));
        private ReadOnlyCollection<IWebElement> ProductPrices => webDriver.FindElements(By.XPath("//div[@class='schema-product__price']//span"));
        private IWebElement SortDropdownBtn => webDriver.FindElement(By.XPath("//div[@id='schema-order']"));
        private IWebElement FilterTag => webDriver.FindElement(By.XPath("//span[@class='schema-tags__text']"));
        private IWebElement NextProductPage => Driver.CreateWebDriverWait(webDriver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='schema-pagination']/a")));
        private IWebElement PaginationDropdownBtn => webDriver.FindElement(By.XPath("//div[@class='schema-pagination__dropdown']"));
 
        public void OpenSortingPanel()
        {
            SortDropdownBtn.Click();
        }

        public void SelectSortingType(string sortingName)
        {
            var el = webDriver.FindElement(By.XPath($"//div[contains(@class,'schema-order__item')]//span[text()='{sortingName}']"));
            el.Click();
        }

        public List<string> GetProductPrices()
        {
            List<string> prices = new List<string>();
            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                prices.Clear();
                ProductPrices.ToList().ForEach(el => prices.Add(el.Text));
                return true;
            });
            return prices;
        }

        public List<string> GetProductTitels()
        {
            List<string> titels = new List<string>();
            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                titels.Clear();
                ProductsTitels.ToList().ForEach(el => titels.Add(el.Text));
                return true;
            });
            return titels;
        }
        
        public int GetCurrentPageIndex()
        {
            var pageIndex = PaginationDropdownBtn.FindElement(By.XPath(".//div[contains(@class,'value')]")).Text;
            return Int32.Parse(pageIndex);
        }

        public void ClickOnPaginationPage(int pageNumber)
        {
            webDriver.FindElement(By.XPath($"//div[@id='mCSB_1_container']//a[text()='{pageNumber}']")).Click();
        }

        public void ProceedToNextProductPage()
        {         
            actions.MoveToElement(NextProductPage).Perform();
            PaginationDropdownBtn.Click();
            var pageNumber = GetCurrentPageIndex() + 1;
            ClickOnPaginationPage(pageNumber);

                Driver.CreateWebDriverWait(webDriver).Until(waiting =>
                {
                    var el = webDriver.FindElement(By.XPath($"//div[@id='mCSB_1_container']//a[text()='{GetCurrentPageIndex()}']")).GetCssValue("background-color");
                    return ServiceHelper.ConvertRGBToHex(el) == "#555555";
                });

                Driver.CreateWebDriverWait(webDriver).Until(waiting =>{ return ProductsTitels.Count > 0; });
        }

        public bool IsLastPage()
        {
            bool result = NextProductPage.GetAttribute("class").Contains("disabled");      
            return result;
        }

        public ReadOnlyCollection<IWebElement> FindAllFiltersFromSection(string filterName)
        {
            var filters = webDriver.FindElements(By.XPath($"//span[text()='{filterName}']/ancestor-or-self::div[contains(@class,'field')]//li//span[@class='i-checkbox']")); 
            return filters;
        }

        public void SelectFilterByIndexFromSection(string filterName, int filterIndex)
        {
            var filter = FindAllFiltersFromSection(filterName)[filterIndex];

            js.ExecuteScript("arguments[0].scrollIntoView(true)", filter);
            filter.Click();
        }

        public string GetSelectedFilter()
        {
            return FilterTag.Text;
        }

        public void ClickOnFirstItemInProductGrid()
        {
            ProductsGrid[0].Click();
        }
    }
}
