using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace Onliner.Pages
{
    class PreviewResultPage : BasePage
    {

        public PreviewResultPage (IWebDriver driver)
        {
            WebDriver = driver;
        }

        private ReadOnlyCollection<IWebElement> SearchResult => WebDriver.FindElements(By.XPath("//li[@class='search__result']//a[@class='category__title']"));
        private IWebElement ModalIframe => WebDriver.FindElement(By.XPath("//iframe[@class='modal-iframe']"));

        public void SelectProduct(string value)
        {
            SwitchToIframe(ModalIframe);
            FindCertainElementFromGrid(SearchResult, value).Click();
        }
    }
}
