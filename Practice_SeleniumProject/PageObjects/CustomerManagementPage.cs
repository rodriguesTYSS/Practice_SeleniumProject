using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    public class CustomerManagementPage
    {
        public IWebDriver driver;
        public CustomerManagementPage (IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement addCustomerBtn => driver.FindElement(By.XPath("//button[contains(text(),'Add')]"));


        public IWebElement deleteSelectCustomerBtn => driver.FindElement(By.XPath("//strong[contains(text(), ' Delete Selected')]"));

        public IWebElement customerCheckbox => driver.FindElement(By.XPath("//td[text()='Prakash']/preceding-sibling::td/input"));

        public IWebElement AllcustomerCheckbox => driver.FindElement(By.Id("select_all"));

        public IWebElement deleteAllCustomerBtn => driver.FindElement(By.Id("deleteAll"));

    }
}
