using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Onliner.Pages
{
    class BookmarkPage : BasePage
    {
        public BookmarkPage (IWebDriver driver)
        {
                WebDriver = driver;
        }

        private IWebElement ProductsGrid => WebDriver.FindElement(By.XPath("//td[@class='pimage']"));
        private IWebElement SelectAllBtn => WebDriver.FindElement(By.XPath("//input[@id='selectAllBookmarks']"));
        private IWebElement RemoveBtn => WebDriver.FindElement(By.XPath("//i[@class='b-ico']/ancestor::a"));

        public void RemoveAllProduct()
        {
            SelectAllBtn.Click();
            RemoveBtn.Click();
        }

        public bool IsProductDisplayed(string value)
        {
            var el = ProductsGrid.FindElement(By.XPath($"//img[contains(@src,'{value}')]"));
            return el.Displayed;
        }
    }
}
