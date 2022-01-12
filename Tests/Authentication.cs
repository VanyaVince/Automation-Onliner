using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;

namespace Onliner.Tests
{
    public class Authentication : BaseTest
    {
        private readonly int expectedId = 3397717;        

        private HomePage homePage;
        private LoginPage loginPage;
        private Driver driver;

        [SetUp]
        public void Setup()
        {
            driver = new Driver();
            homePage = new HomePage(driver.CurrentDriver);
            loginPage = new LoginPage(driver.CurrentDriver);
        }

        [Test]
        public void LoginSuccessfullyTest()
        {

            homePage.OpenUrl();
            homePage.ClickOnLoginBtn();
            loginPage.EnterNickname(NicknameValue);
            loginPage.EnterPassword(PasswordValue);
            loginPage.ClickOnSubmitBtn();
            homePage.ClickOnProfileItem();

            Assert.AreEqual(expectedId, homePage.GetUserId());
        }

        [Test]
        public void LogoutSuccessfullyTest()
        {
            homePage.OpenUrl();
            homePage.ClickOnLoginBtn();
            loginPage.EnterNickname(NicknameValue);
            loginPage.EnterPassword(PasswordValue);
            loginPage.ClickOnSubmitBtn();
            homePage.ClickOnProfileItem();
            homePage.ClickOnLogoutBtn();

            Assert.IsTrue(homePage.IsLoginBtnDisplayed());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            homePage.OpenUrl();
            homePage.ClickOnLoginBtn();
            loginPage.EnterNickname($"{NicknameValue}Bar");
            loginPage.EnterPassword(PasswordValue);
            loginPage.ClickOnSubmitBtn();

            Assert.IsTrue(loginPage.IsLoginErrorDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Quit();
        }
    }
}