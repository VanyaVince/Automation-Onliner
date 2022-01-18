using Onliner.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.steps
{
    public class LoginPageSteps
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        public LoginPageSteps(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _loginPage = new LoginPage(driver);
        }

        public void Login(string nicknameValue, string passwordValue)
        {
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname(nicknameValue);
            _loginPage.EnterPassword(passwordValue);
            _loginPage.ClickOnSubmitBtn();
        }

        public bool IsLoginErrorDisplayed()
        {
            return _loginPage.IsLoginErrorDisplayed();
        }
    }
}
