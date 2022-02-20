//using DebionTradePlatform.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireTest.Services
{
    public class BrowserService 
    {
        public IWebDriver Driver;

        public BrowserService()
        {
            Driver = new ChromeDriver();
        }
        public BrowserService(IWebDriver driver)
        {
            this.Driver = driver;
        }

        //public IWebDriver Driver;
        //public BrowserService(IWebDriver driver)
        //{
        //    Driver = driver;
        //}
        //public void Init()
        //{
        //    Driver = new ChromeDriver();
        //}


        public void OpenURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
        }
        public void RefreshBrowser()
        {
            Driver.Navigate().Refresh();
        }                      
        public void CloseBrowser()
        {
            Driver.Quit();
        }        
    }
}
