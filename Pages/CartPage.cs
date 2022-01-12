using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Pages
{
    class CartPage : BasePage
    {
        //private ReadOnlyCollection<IWebElement> ProductTitels => WebDriver.FindElements(By.XPath("//div[contains(@class,'image')]/following-sibling::div//a[not(contains(@class,'button'))]"));

        public CartPage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement FindProductContainer(string value)
        {
            return webDriver.FindElement(By.XPath($"//img[@src='{value}']//ancestor::div[contains(@class,'unit')]"));
        }

        public void DeleteProduct(string title)
        {
            string deleteBtn = "//a[contains(@class,'remove')]";
            IWebElement removeBtn = FindProductContainer(title).FindElement(By.XPath(deleteBtn));
            Actions actions = new Actions(webDriver);
            actions.MoveToElement(removeBtn).Perform();
            removeBtn.Click();
        }

        public bool IsProductRemoved(string value)
        {
            string name = "//div[contains(@class,'offers-part_vertical_middle')]";
            return FindProductContainer(value).FindElement(By.XPath(name)).Displayed;
        }
    }
}
