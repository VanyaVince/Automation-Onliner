using NUnit.Framework;
using SpeckflowOnliner.Drivers;
using SpeckflowOnliner.Pages;

namespace SpeckflowOnliner.Steps
{
    public class Authorization
    {
        private int expectedId = 3397717;

        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        private Driver driver = new Driver();

        public Authorization()
        {
            _homePage = new HomePage(driver.CurrentDriver);
            _loginPage = new LoginPage(driver.CurrentDriver);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginSuccessfullyTest()
        {
            _homePage.OpenUrl();
            _homePage.ClickOnLoginBtn();
            _loginPage.EnterNickname();
            _loginPage.EnterPassword();
            _loginPage.ClickOnSubmitBtn();
            _homePage.ClickOnProfileItem();

            var actualId = _homePage.GetUserId();

            Assert.AreEqual(expectedId, actualId);
        }

        [TearDown]
        public void TearDown()
        {
            driver.CurrentDriver.Close();
        }
    }
}
