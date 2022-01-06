using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;

namespace Onliner.Tests
{
    public class Authentication
    {
        private int expectedId = 3397717;

        private HomePage homePage;
        private LoginPage loginPage;
        private Driver driver;

        public Authentication()
        {
        }

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
            loginPage.EnterNickname();
            loginPage.EnterPassword();
            loginPage.ClickOnSubmitBtn();
            homePage.ClickOnProfileItem();

            var actualId = homePage.GetUserId();

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void LogoutSuccessfullyTest()
        {
            homePage.OpenUrl();
            homePage.ClickOnLoginBtn();
            loginPage.EnterNickname();
            loginPage.EnterPassword();
            loginPage.ClickOnSubmitBtn();
            homePage.ClickOnProfileItem();
            homePage.ClickOnLogoutBtn();
            Assert.IsTrue(homePage.IsLoginBtnDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Close();
        }
    }
}