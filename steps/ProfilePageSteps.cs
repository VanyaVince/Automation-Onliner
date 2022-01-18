using Onliner.Pages;
using OpenQA.Selenium;


namespace Onliner.steps
{
    public class ProfilePageSteps
    {
        private readonly ProfilePage _profilePage;

        public ProfilePageSteps(IWebDriver driver)
        {
            _profilePage = new ProfilePage(driver);
        }

        public void AmendFullName(string lastName, string firstName, string patronymic)
        {
            _profilePage.ClickOnAmendFullNameBtn();
            _profilePage.InputLastName(lastName);
            _profilePage.InputFirstName(firstName);
            _profilePage.InputPatronymic(patronymic);
            _profilePage.ClickOnSaveBtn();
        }

        public string GetFullName()
        {
            return _profilePage.GetFullName();
        }
    }
}
