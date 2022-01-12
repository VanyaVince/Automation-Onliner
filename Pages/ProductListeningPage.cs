using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Onliner.Drivers;

namespace Onliner.Pages
{
    public class ProductListeningPage: BasePage
    {
        public ProductListeningPage(IWebDriver driver)
            : base(driver)
        {
        }

        private ReadOnlyCollection<IWebElement> ProductsGrid => webDriver.FindElements(By.XPath("//div[@class='schema-product__group']//div[contains(@class,'part_1')]//a[contains(@data-bind,'product.html')]"));
        private ReadOnlyCollection<IWebElement> ProductsTitels => webDriver.FindElements(By.XPath("//span[contains(@data-bind,'product.full_name')]"));
        private IWebElement FilterTag => webDriver.FindElement(By.XPath("//span[@class='schema-tags__text']"));
        private IWebElement NextProductPage => Driver.CreateWebDriverWait(webDriver).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='schema-pagination']/a")));

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

        public List<string> GetProductTitels(List<string> list)
        {
            ProductsTitels.ToList().ForEach(x => list.Add(x.Text));
            return list;
        }
        
        public void ProceedToNextProductPage()
        {
            while (IsLastPage())
            {
                actions.MoveToElement(NextProductPage).Perform();
                NextProductPage.Click();
            }
        }

        public bool IsLastPage()
        {
            bool result = NextProductPage.GetAttribute("class").Contains("disabled");
            Console.WriteLine($"GetAttribute of disabled equals to  {result}");
            return !result;
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
