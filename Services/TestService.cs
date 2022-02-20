using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AspireTest.Services
{
    public class TestService
    {
        //public Browser browser;
        //public BaseTest()
        //{
        //    browser = new Browser();
        //    browser.Init();
        //}

        public IWebDriver Driver;

        public TestService()
        {
            Driver = new ChromeDriver();
            Init();
        }

        public TestService(IWebDriver driver)
        {
            this.Driver = driver;
            Init();
        }

        public virtual void Init()
        {

        }
    }
}
