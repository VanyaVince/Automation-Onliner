using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support;
using Onliner.Drivers;
using OpenQA.Selenium;
using NUnit.Framework;

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

        public List<string> GetProductTitels(List<string> list)
        {
            ProductsTitels.ToList().ForEach(x => list.Add(x.Text));
            return list;
        }
        
        public int GetCurrentPageIndex()
        {
            return Int32.Parse(PaginationDropdownBtn.FindElement(By.XPath(".//div[contains(@class,'value')]")).Text);
        }

        public IWebElement ClickOnNextPaginationPage()
        {
            var currentPage = GetCurrentPageIndex();

            Console.WriteLine($"current page number {currentPage}");

            var nextPaginationPage = webDriver.FindElement(By.XPath($"//div[@id='mCSB_1_container']//a[text()='{currentPage + 1}']"));

            return nextPaginationPage;
        }

        public void ProceedToNextProductPage()
        {
            List<string> list = new List<string>();

            while (IsLastPage())
            {
                GetProductTitels(list);
                actions.MoveToElement(NextProductPage).Perform();

                PaginationDropdownBtn.Click();
                ClickOnNextPaginationPage().Click();

                Driver.CreateWebDriverWait(webDriver).Until(waiting =>
                {
                    var el = webDriver.FindElement(By.XPath($"//div[@id='mCSB_1_container']//a[text()='{GetCurrentPageIndex()}']")).GetCssValue("background-color");
                    return ConvertRGBToHex(el) == "#555555";
                });

                Driver.CreateWebDriverWait(webDriver).Until(waiting =>
                {
                    return ProductsTitels.Count > 0;
                });
            }

            GetProductTitels(list);

            Console.WriteLine("filter name " + GetSelectedFilter());
            Assert.IsTrue(list.All(x => x.Contains(GetSelectedFilter())));
            Console.WriteLine($"number of products within list {list.Count}");
        }


        public string ConvertRGBToHex(string rjb)
        {
            string[] numbers = rjb.Replace("rgba(", "").Replace(")", "").Split(",");

            int r = Int32.Parse(numbers[0].Trim());
            int g = Int32.Parse(numbers[1].Trim());
            int b = Int32.Parse(numbers[2].Trim());

            return string.Format("#{0:X1}{1:X1}{2:X1}", r, g, b);
        }

        public bool IsLastPage()
        {
            bool result = NextProductPage.GetAttribute("class").Contains("disabled");
            Console.WriteLine($"GetAttribute of disabled equals to  {result}");
            return !result;
        }

        public IWebElement FindFilterSection(string value)
        {
            return webDriver.FindElement(By.XPath($"//span[text()='{value}']/ancestor-or-self::div[contains(@class,'field')]"));
        }

        public ReadOnlyCollection<IWebElement> GetManufacturerFilterGrid(string value)
        {
            return FindFilterSection($"{value}").FindElements(By.XPath(".//li//span[@class='i-checkbox']"));
        }

        public void SelectManufactureFilter(string value)
        {
            var filtersItems = GetManufacturerFilterGrid(value);
            var randomNumber = random.Next(filtersItems.Count);
            var el = filtersItems[0];

            js.ExecuteScript("arguments[0].scrollIntoView(true)", el);
            el.Click();
            js.ExecuteScript("window.scrollTo(0,0)");
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
