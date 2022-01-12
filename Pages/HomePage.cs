using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Network;
using OpenQA.Selenium.Support.UI;
using Onliner.Drivers;

namespace Onliner.Pages
{
    class HomePage : BasePage
    {
        private string url = "https://www.onliner.by/";

        public HomePage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement ProfileIcon => webDriver.FindElement(By.XPath("//div[contains(@class,'avatar')]"));
        private IWebElement UserId => webDriver.FindElement(By.XPath("//div[contains(@class,'profile__name')]/a"));
        private IWebElement LoginBtn => webDriver.FindElement(By.XPath("//div[@id='userbar']//div[contains(@class, 'auth-bar__item--text')]"));
        private IWebElement LogoutBtn => webDriver.FindElement(By.XPath("//div[contains(@class, 'logout')]/a"));
        private IWebElement SearchField => webDriver.FindElement(By.XPath("//input[@name='query']"));

        public void OpenUrl()
        {
            webDriver.Navigate().GoToUrl(url);
        }
        public void SearchProduct(String value) 
        {
            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                SearchField.SendKeys(value);
                return true;
            });
        }
        public void ClickOnLoginBtn()
        {
            LoginBtn.Click();
        }
        public void ClickOnProfileItem()
        {
            ProfileIcon.Click();
        }

        public void ClickOnLogoutBtn()
        {
            LogoutBtn.Click();
        }
        
        public int GetUserId()
        {
            return int.Parse(UserId.Text);
        }

        public bool IsLoginBtnDisplayed()
        {
            return LoginBtn.Displayed;
        }
    }
}