using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Onliner.Pages
{
    class BookmarkPage : BasePage
    {
        public BookmarkPage (IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement ProductsGrid => webDriver.FindElement(By.XPath("//td[@class='pimage']"));
        private IWebElement SelectAllBtn => webDriver.FindElement(By.XPath("//input[@id='selectAllBookmarks']"));
        private IWebElement RemoveBtn => webDriver.FindElement(By.XPath("//i[@class='b-ico']/ancestor::a"));

        public void ClickOnRemoveBtn()
        {
            RemoveBtn.Click();
        }

        public void ClickOnSelectAllBtn()
        {
            SelectAllBtn.Click();
        }

        public bool IsProductDisplayed(string value)
        {
            var el = ProductsGrid.FindElement(By.XPath($"//img[contains(@src,'{value}')]"));
            return el.Displayed;
        }
    }
}
