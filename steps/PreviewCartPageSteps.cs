using Onliner.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.steps
{
    public class PreviewCartPageSteps
    {
        private readonly PreviewCartPage previewCartPage;

        public PreviewCartPageSteps(IWebDriver driver)
        {
            previewCartPage = new PreviewCartPage(driver);
        }

        public void ProceedToCart()
        {
            previewCartPage.ClickOnProceedToCartBtn();
        }
    }
}
