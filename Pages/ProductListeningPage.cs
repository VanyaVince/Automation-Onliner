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
        private IWebElement FilterTag => webDriver.FindElement(By.XPath("//span[@class='schema-tags__text']"));
        private IWebElement NextProductPage => Driver.CreateWebDriverWait(webDriver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='schema-pagination']/a")));
        private IWebElement PaginationDropdownBtn => webDriver.FindElement(By.XPath("//div[@class='schema-pagination__dropdown']"));

        public void GetProductTitels(List<string> productTitleList)
        {
            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                ProductsTitels.ToList().ForEach(el => productTitleList.Add(el.Text));
                return true;
            });

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

                Driver.CreateWebDriverWait(webDriver).Until(waiting =>
                {
                    return ProductsTitels.Count > 0;
                });
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

        public void ClickOnFirstItem()
        {
            ProductsGrid[0].Click();
        }
    }
}
