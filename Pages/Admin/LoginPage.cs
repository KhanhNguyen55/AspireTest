using AspireTest.Services;
//using DebionTradePlatform.Services;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireTest.Pages.Admin
{
    internal class LoginPage : PageService
    {
        readonly BrowserService browserService;
        readonly ElementService elementService;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            browserService = new BrowserService(driver);
            elementService = new ElementService();
        }

        #region
        public IWebElement FieldEmail => Element("//input[@id='login']");
        public IWebElement FieldPassword => Element("//input[@id='password']");
        public IWebElement ButtonLogin => Element("//button[text()='Log in']");
        #endregion

        public void LoginAdmin(string url, string email, string password)
        {
            browserService.OpenURL(url);
            elementService.Input(FieldEmail, email);
            elementService.Input(FieldPassword, password);
            ButtonLogin.Click();
        }
    }
}
