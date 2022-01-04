using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;

namespace SpeckflowOnliner.Pages
{
    class BasePage
    {
        protected IWebDriver WebDriver;

        protected void SwitchToIframe(IWebElement iframe)
        {
            WebDriver.SwitchTo().Frame(iframe);
        }

        protected IWebElement FindCertainElementByText(ReadOnlyCollection<IWebElement> list, String value)
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
