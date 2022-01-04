using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SpeckflowOnliner.Pages
{
    class BookmarkPage :BasePage
    {
        public BookmarkPage (IWebDriver driver)
        {
                WebDriver = driver;
        }
        private ReadOnlyCollection<IWebElement> favoritesProdtucts => WebDriver.FindElements(By.XPath("//strong[@class='pname']//a"));

        public string GetSpecificProductName(string value)
        {
            return FindCertainElementByText(favoritesProdtucts, value).Text;
        }
    }
}
