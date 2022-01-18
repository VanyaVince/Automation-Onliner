using NUnit.Framework;
using Onliner.Drivers;
using Onliner.Pages;
using Onliner.steps;
using Onliner.Utils;
using System.Threading;

namespace Onliner.Tests
{
    public class Profile : BaseTest
    {
        private readonly string  _lastName = ServiceHelper.GenerateRandomValue(10);
        private readonly string  _firstName = ServiceHelper.GenerateRandomValue(10);
        private readonly string _patronymic = ServiceHelper.GenerateRandomValue(10);    

        [SetUp]
        public void Setup()
        {
            driver = new Driver();
            homePageSteps = new HomePageSteps(driver.CurrentDriver);
            loginPageSteps = new LoginPageSteps(driver.CurrentDriver);
            productListeningPageSteps = new ProductListeningPageSteps(driver.CurrentDriver);
            profilePageSteps = new ProfilePageSteps(driver.CurrentDriver);
        }

        [Test]
        public void AmendPersonalDataTest()
        {
            homePageSteps.OpenUrl(url);
            loginPageSteps.Login(NicknameValue, PasswordValue);
            homePageSteps.OpenProfilePopup();

            homePageSteps.OpenPersonalSettings();

            profilePageSteps.AmendFullName(_lastName, _firstName, _patronymic);

            var fullName = string.Format("{0} {1} {2}", _lastName, _firstName, _patronymic);

             Assert.AreEqual(fullName, profilePageSteps.GetFullName()); 
        }
    }
}
