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
    public class InventoryPage : PageService
    {
        readonly ElementService elementService;
        public InventoryPage(IWebDriver driver) : base(driver)
        {
            elementService = new ElementService();
        }

        #region
        public IWebElement TextInventoryOverview => Element("//span[text()='Inventory Overview']");
        public IWebElement MenuProducts => Element("//span[text()='Products']");
        public IWebElement SubMenuProduct => Element("//a[text()='Products']");
        public IWebElement TextProduct => Element("//li/span[text()='Products']");
        public IWebElement ButtonCreate => Element("//button[contains(text(),'Create')]");
        public IWebElement TextNew => Element("//span[text()='New']");
        public IWebElement FieldProductName => Element("//input[@id='o_field_input_11']");
        public IWebElement LinkUpdateQuantity => Element("//span[text()='Update Quantity']");
        public IWebElement FieldCountedQuantity => Element("//input[@name='inventory_quantity']");
        public IWebElement FieldUpdatedCounterQuantity => Element("//span[@name='inventory_quantity']");
        public IWebElement ButtonSave => Element("//button[contains(text(),'Save')]");
        public IWebElement ButtonHomeMenu => Element("//a[@title='Home menu']");
        #endregion

        public void OpenMenu(IWebElement menubElement, IWebElement submenuElement)
        {
            menubElement.Click();
            submenuElement.Click();
            TextProduct.Displayed.Should().BeTrue();
        }
        public void OpenProductMenu()
        {
            MenuProducts.Click();
            SubMenuProduct.Click();
            TextProduct.Displayed.Should().BeTrue();
        }
        public void CreateProduct(string productName)
        {
            ButtonCreate.Click();
            TextNew.Displayed.Should().BeTrue();
            
            elementService.Input(FieldProductName, productName);
            LinkUpdateQuantity.Click();
            ButtonCreate.Displayed.Should().BeTrue();
        }
        public void UpdateQuantity(string quantity)
        {
            ButtonCreate.Click();
            FieldCountedQuantity.Displayed.Should().BeTrue();

            elementService.Input(FieldCountedQuantity, quantity);
            ButtonSave.Click();
            Thread.Sleep(2000);

            FieldUpdatedCounterQuantity.Text.Should().Contain(quantity);
        }
    }
}
