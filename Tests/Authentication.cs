using NUnit.Framework;
using Onliner.Drivers;
using Onliner.steps;
using Onliner.Utils;

namespace Onliner.Tests
{
    public class Authentication : BaseTest
    {
        private readonly string expectedId = "3397717";        

        [SetUp]
        public void Setup()
        {
            driver = new Driver();
            homePageSteps = new HomePageSteps(driver.CurrentDriver);
            loginPageSteps = new LoginPageSteps(driver.CurrentDriver);
        }

        [Test]
        public void LoginSuccessfullyTest()
        {
            homePageSteps.OpenUrl(url);
            loginPageSteps.Login(NicknameValue, PasswordValue);
            homePageSteps.OpenProfilePopup();

            Assert.AreEqual(expectedId, homePageSteps.GetUserId());
        }

        [Test]
        public void LogoutSuccessfullyTest()
        {
            homePageSteps.OpenUrl(url);
            loginPageSteps.Login(NicknameValue, PasswordValue);
            homePageSteps.Logout();

            Assert.IsTrue(homePageSteps.IsLoginBtnDisplayed());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            homePageSteps.OpenUrl(url);
            loginPageSteps.Login(ServiceHelper.GenerateRandomValue(10), PasswordValue);

            Assert.IsTrue(loginPageSteps.IsLoginErrorDisplayed());
        }
    }
}