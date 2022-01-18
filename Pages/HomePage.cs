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
        public HomePage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement ProfileIcon => webDriver.FindElement(By.XPath("//div[contains(@class,'avatar')]"));
        private IWebElement UserId => webDriver.FindElement(By.XPath("//div[contains(@class,'profile__name')]/a"));
        private IWebElement LoginBtn => webDriver.FindElement(By.XPath("//div[@id='userbar']//div[contains(@class, 'auth-bar__item--text')]"));
        private IWebElement LogoutBtn => webDriver.FindElement(By.XPath("//div[contains(@class, 'logout')]/a"));
        private IWebElement SearchField => webDriver.FindElement(By.XPath("//input[@name='query']"));
        private IWebElement ProfileSettingsBtn => webDriver.FindElement(By.XPath("//a[contains(@class,'profile__settings')]"));

        public void OpenUrl(string url)
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

        public void ClickOnProfileSettingsBtn()
        {
            ProfileSettingsBtn.Click();
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
        
        public string GetUserId()
        {
            return UserId.Text;
        }

        public bool IsLoginBtnDisplayed()
        {
            return LoginBtn.Displayed;
        }
    }
}