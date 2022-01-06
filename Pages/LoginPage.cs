using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Onliner.Pages
{
    class LoginPage : BasePage
    {
        private const string NicknameValue = "vanyavince@gmail.com";
        private const string PasswordValue = "Tarakan!0508";
        public LoginPage(IWebDriver driver)
        {
            WebDriver = driver;
        }

        //private IWebElement a = WebDriver.FindElement(By.XPath(""))
        private IWebElement NicknameField => WebDriver.FindElement(By.XPath("//div[@class='auth-form__field']//input[contains(@placeholder, 'e-mail')]"));
        private IWebElement PasswordField => WebDriver.FindElement(By.XPath("//div[contains(@class, 'helper_visible')]//preceding-sibling::input"));
        private IWebElement SubmitBtn => WebDriver.FindElement(By.XPath("//div[@class='auth-form__body']//button[@type='submit']"));

        public void EnterNickname()
        {
            NicknameField.SendKeys(NicknameValue);
        }

        public void EnterPassword()
        {
            PasswordField.SendKeys(PasswordValue);
        }

        public void ClickOnSubmitBtn()
        {
            SubmitBtn.Click();
        }
    }
}
