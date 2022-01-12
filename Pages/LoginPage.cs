using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Onliner.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        private IWebElement NicknameField => webDriver.FindElement(By.XPath("//div[@class='auth-form__field']//input[contains(@placeholder, 'e-mail')]"));
        private IWebElement PasswordField => webDriver.FindElement(By.XPath("//div[contains(@class, 'helper_visible')]//preceding-sibling::input"));
        private IWebElement SubmitBtn => webDriver.FindElement(By.XPath("//div[@class='auth-form__body']//button[@type='submit']"));
        private IWebElement LoginErrorLabel => webDriver.FindElement(By.XPath("//div[contains(@class,'error')]"));

        public void EnterNickname(string value)
        {
            NicknameField.SendKeys(value);
        }

        public void EnterPassword(string value)
        {
            PasswordField.SendKeys(value);
        }

        public void ClickOnSubmitBtn()
        {
            SubmitBtn.Click();
        }

        public bool IsLoginErrorDisplayed()
        {
            return LoginErrorLabel.Displayed;
        }
    }
}
