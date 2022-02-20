using AspireTest.Services;
//using DebionTradePlatform.Services;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspireTest.Pages.Admin
{
    public class ManufacturingOrdersPage : PageService
    {
        readonly ElementService elementService;
        public ManufacturingOrdersPage(IWebDriver driver) : base(driver)
        {
            elementService = new ElementService();
        }

        #region
        public IWebElement TextManufacturingOrders => Element("//li/span[text()='Manufacturing Orders']");
        public IWebElement ButtonCreate => Element("//button[contains(text(),'Create')]");
        public IWebElement FieldProductSelection => Element("//tr[.//label[text()='Product']]/td[last()]//input");
        public IWebElement OptionSearchMore => Element("//a[text()='Search More...']");
        public IWebElement FieldSearchProduct => Element("//input[@title='Search for records']");
        public IWebElement ResultRow(string productName) => Driver.FindElement(By.XPath($"//td[contains(@title,'{productName}')]"));
        public IWebElement ButtonSave => Element("//button[contains(text(),'Save')]");
        public IWebElement ButtonConfirm => Element("//span[contains(text(),'Confirm')]");
        public IWebElement ButtonMarkAsDone => Element("(//span[contains(text(),'Mark as Done')])[2]");
        public IWebElement ButtonOkInConfirmation => Element("//span[text()='Ok']");
        public IWebElement ButtonApplyInConfirmation => Element("//span[text()='Apply']");
        public IWebElement TextCurrentState => Element("//div[@name='state']/button[@title='Current state']");
        #endregion

        public void CreateNewManufacturingOrders()
        {
            ButtonCreate.Click();
            FieldProductSelection.Displayed.Should().BeTrue();
        }
        public void SelectProduct(string productName)
        {
            FieldProductSelection.Click();
            OptionSearchMore.Click();
            FieldSearchProduct.Displayed.Should().BeTrue();

            elementService.Input(FieldSearchProduct, productName);
            FieldSearchProduct.SendKeys(Keys.Enter);

            // it take time to display.
            Thread.Sleep(2000);
            ResultRow(productName).Displayed.Should().BeTrue();
            ResultRow(productName).Click();
            Thread.Sleep(2000);
        }
        public void MarkOrderAsDone()
        {
            ButtonMarkAsDone.Click();
            ButtonOkInConfirmation.Click();
            ButtonApplyInConfirmation.Click();

            // slow down to get correct result.
            Thread.Sleep(2000);
        }
    }
}
