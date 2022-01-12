using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Onliner.Pages
{
    public class BasePage
    {
        protected IWebDriver webDriver;
        protected IJavaScriptExecutor js;
        protected Actions actions;
        protected Random random;


        public BasePage(IWebDriver driver)
        {
            webDriver = driver;
            js = (IJavaScriptExecutor)webDriver;
            actions = new Actions(webDriver);
            random = new Random();
        }

        protected void SwitchToIframe(IWebElement iframe)
        {
            webDriver.SwitchTo().Frame(iframe);
        }

        protected IWebElement FindCertainElementFromGrid(ReadOnlyCollection<IWebElement> list, String value)
        {
            foreach (var element in list)
            {
                if (element.Text == value)
                    return element;
            }
            throw new NoSuchElementException();
        } 
    }
}
