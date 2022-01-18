using NUnit.Framework;
using Onliner.Drivers;
using Onliner.steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onliner.Tests
{
    public class BaseTest
    {
        protected string url = "https://www.onliner.by/";
        protected readonly string NicknameValue = "vanyavince@gmail.com";
        protected readonly string PasswordValue = "Tarakan!0508";

        protected Driver driver;
        protected HomePageSteps homePageSteps;
        protected LoginPageSteps loginPageSteps;
        protected ProductListeningPageSteps productListeningPageSteps;
        protected ProductPageSteps productPageSteps;
        protected BookmarkPageSteps bookmarkPageSteps;
        protected PreviewCartPageSteps previewCartPageSteps;
        protected CartPageSteps cartPageSteps;
        protected ProfilePageSteps profilePageSteps;


        [TearDown]
        public virtual void TearDown()
        {
            driver.CurrentDriver.Quit();
        }
    }
}
