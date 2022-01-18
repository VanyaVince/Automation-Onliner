using Onliner.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.steps
{
    public class HomePageSteps
    {
        private readonly HomePage _homePage;
        private readonly PreviewResultPage _previewResultPage;

        public HomePageSteps(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _previewResultPage = new PreviewResultPage(driver);
        }

        public void OpenUrl(string url)
        {
            _homePage.OpenUrl(url);
        }

        public void OpenProfilePopup()
        {
            _homePage.ClickOnProfileItem();
        }

        public void OpenPersonalSettings()
        {
            _homePage.ClickOnProfileSettingsBtn();
        }

        public void Logout()
        {
            _homePage.ClickOnProfileItem();
            _homePage.ClickOnLogoutBtn();
        }

        public string GetUserId()
        {
            return _homePage.GetUserId();
        }

        public bool IsLoginBtnDisplayed()
        {
            return _homePage.IsLoginBtnDisplayed();
        }

        public void SearchForProduct(string product)
        {
            _homePage.SearchProduct(product);
            _previewResultPage.SelectProduct(product);
        }
    }
}
