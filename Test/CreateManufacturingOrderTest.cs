using AspireTest.Constansts;
using AspireTest.Pages.Admin;
using AspireTest.Services;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireTest.Test
{
    public class CreateManufacturingOrderTest : TestService
    {
        readonly LoginPage loginPage;
        readonly HomePage homePage;
        readonly InventoryPage inventoryPage;
        readonly ManufacturingOrdersPage manufacturingOrdersPage;
        public CreateManufacturingOrderTest()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);

            inventoryPage = new InventoryPage(Driver);
            manufacturingOrdersPage = new ManufacturingOrdersPage(Driver);
        }

        [Xunit.Fact]
        [Xunit.Trait("Action", "CreateManufacturingOrder")]
        public void VerifyTradeFlowCustomRFQ()
        {
            // 1. Login to web application
            loginPage.LoginAdmin(Accounts.adminLoginURL, Accounts.adminEmail, Accounts.adminPassword);
            homePage.CheckLoginSuccess();

            // 2. Navigate to 'Inventory' feature
            homePage.ButtonInventory.Click();
            inventoryPage.TextInventoryOverview.Displayed.Should().BeTrue();

            // 3. From the top-menu bar, select `Products -> Products` item, then create a new product
            inventoryPage.OpenProductMenu();
            DateTime dateTime = DateTime.Now;
            string productName = "khanh test " + dateTime.ToString("hh"+"mm"+"ss");
            inventoryPage.CreateProduct(productName);

            // 4. Update the quantity of new product is more than 10
            inventoryPage.UpdateQuantity("18");

            // 5. From top-left page, click on 'Application' icon
            inventoryPage.ButtonHomeMenu.Click();
            homePage.ButtonManufacturing.Click();

            // 6. Navigate to `Manufacturing` feature, then create a new Manufacturing Order item for the created Product on step #3
            manufacturingOrdersPage.TextManufacturingOrders.Displayed.Should().BeTrue();
            manufacturingOrdersPage.CreateNewManufacturingOrders();
            manufacturingOrdersPage.SelectProduct(productName);
            manufacturingOrdersPage.ButtonConfirm.Click();

            // 7. Update the status of new Orders to “Done” successfully
            manufacturingOrdersPage.MarkOrderAsDone();
            manufacturingOrdersPage.TextCurrentState.Text.Should().Contain("DONE");

            Driver.Quit();
        }
    }
}
