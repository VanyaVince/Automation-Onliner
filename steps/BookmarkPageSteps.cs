using Onliner.Pages;
using OpenQA.Selenium;

namespace Onliner.steps
{
    public class BookmarkPageSteps
    {
        private readonly BookmarkPage _bookmarkPage;

        public BookmarkPageSteps(IWebDriver driver)
        {
            _bookmarkPage = new BookmarkPage(driver);
        }

        public bool IsProductDisplayed(string productId)
        {
            return _bookmarkPage.IsProductDisplayed(productId);
        }

        public void RemoveAllProduct()
        {
            _bookmarkPage.ClickOnSelectAllBtn();
            _bookmarkPage.ClickOnRemoveBtn();
        }
    }
}
