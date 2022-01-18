using Onliner.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Pages
{
    public class ProfilePage : BasePage
    {
        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AmendNickNameBtn => webDriver.FindElement(By.XPath("//div[contains(@class,'set-item_person')]//a"));
        private IWebElement LastNameInputField => webDriver.FindElement(By.XPath("//input[@placeholder='Фамилия']"));
        private IWebElement FirstNameInputField => webDriver.FindElement(By.XPath("//input[@placeholder='Имя']"));
        private IWebElement PatronymicInputField => webDriver.FindElement(By.XPath("//input[@placeholder='Отчество']"));
        private IWebElement SaveDataBtn => webDriver.FindElement(By.XPath("//div[contains(@class,'auth-form')]//button[@type='submit']"));
        private IWebElement FullNameLabel => webDriver.FindElement(By.XPath("//div[normalize-space() ='ФИО']//ancestor::div[contains(@class,'row_condensed-default')]//span"));


        public void ClickOnAmendFullNameBtn()
        {
            actions.MoveToElement(AmendNickNameBtn).Perform();
            AmendNickNameBtn.Click();
        }

        public void InputLastName(string lastName)
        {
            LastNameInputField.Clear();
            LastNameInputField.SendKeys(lastName);
        }

        public void InputFirstName(string lastName)
        {
            FirstNameInputField.Clear();
            FirstNameInputField.SendKeys(lastName);
        }

        public void InputPatronymic(string lastName)
        {
            PatronymicInputField.Clear();
            PatronymicInputField.SendKeys(lastName);
        }

        public void ClickOnSaveBtn()
        {
            SaveDataBtn.Click();
        }

        public string GetFullName()
        {
            Driver.CreateWebDriverWait(webDriver).Until(waiting =>
            {
                return !string.IsNullOrEmpty(FullNameLabel.Text);
            });

            return FullNameLabel.Text;
        }
    }
}
