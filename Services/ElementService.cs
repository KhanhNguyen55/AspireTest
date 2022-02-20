using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium.Interactions;

namespace AspireTest.Services
{
    public class ElementService
    {
        public IWebDriver Driver;        

        public void Input(IWebElement element, string content)
        {
            element.Click();
            //element.Clear();
            element.SendKeys(content);
        }
        public void InputAndSelectResult(IWebElement element, string content)
        {
            element.Click();
            element.SendKeys(content);
            element.SendKeys(Keys.ArrowDown);
            element.SendKeys(Keys.Enter);
        }
        public bool CheckIfElementExists(IWebElement element)
        {
            bool result;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            try
            {
                result = element.Displayed;
            }
            catch (NoSuchElementException)
            {
                result = false;
            }
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return result;
        }
        public void SelectDropdownValueByText(IWebElement element, string value)
        {
            var selectOption = new SelectElement(element);
            selectOption.SelectByText(value);
        }
        public void SelectDropdownValueByIndex(IWebElement element, int indexValue)
        {
            var SelectOption = new SelectElement(element);
            SelectOption.SelectByIndex(indexValue);
        }
        public string GetSelectedText(IWebElement element)
        {
            var selectElement = new SelectElement(element);
            return selectElement.SelectedOption.Text;
        }
        public void UploadFile(IWebElement element, string filewithpath)
        {
            FileInfo file = new FileInfo(filewithpath);
            string path = file.FullName;
            element.SendKeys(path);
        }
        public void ScrollDownToElement(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
