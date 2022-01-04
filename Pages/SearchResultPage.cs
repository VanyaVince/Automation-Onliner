using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;

namespace SpeckflowOnliner.Pages
{
    class SearchResultPage: BasePage
    {
        public SearchResultPage(IWebDriver driver)
        {
            WebDriver = driver;
        }
        private ReadOnlyCollection<IWebElement> GridItems => WebDriver.FindElements(By.XPath("//div[@class='schema-product__group']//div[contains(@class,'part_1')]//a[contains(@data-bind,'product.html')]"));
        public void ClickOnFirstItem()
        {
            GridItems[0].Click();
        }
    }
}
