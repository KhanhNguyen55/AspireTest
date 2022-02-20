//using DebionTradePlatform.Services;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireTest.Services
{
    public class PageService
    {
        //public Browser browser;
        //public BasePage(Browser browser)
        //{
        //    this.browser = browser;
        //}

        public IWebDriver Driver;
        public PageService(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement Element(string xpath, int wait = 10)
        {
            if (wait != 0) 
            {
                WaitService.WaitFor(() =>
                {
                    return Driver.FindElement(By.XPath(xpath)).Displayed;
                }, wait).Should().BeTrue();
            }
            return Driver.FindElement(By.XPath(xpath));
        }
    }
}
