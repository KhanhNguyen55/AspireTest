using AspireTest.Constansts;
using AspireTest.Services;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireTest.Pages.Admin
{
    public class HomePage : PageService
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        #region
        public IWebElement FieldAvatar => Element("//span[@class='oe_topbar_name']");
        public IWebElement ButtonInventory => Element("//div[text()='Inventory']");        
        public IWebElement ButtonManufacturing => Element("//div[text()='Manufacturing']");
        #endregion

        public void CheckLoginSuccess()
        {
            string avatarName = Accounts.adminEmail.Replace("@aspireapp.com", "");
            FieldAvatar.Text.ToLower().Should().Contain(avatarName);            
        }
    }
}
