using NUnit.Framework;
using OpenQA.Selenium;
using Practice_SeleniumProject.CustomMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    public class AddCustomerPage
    {
        public IWebDriver driver;
        public TestContext TestContext { get; set; }
        public AddCustomerPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement firstNameTextfield => driver.FindElement(By.Name("fname"));

        public IWebElement lastNameTextfield => driver.FindElement(By.Name("lname"));

        public IWebElement emailTextfield => driver.FindElement(By.Name("email"));

        public IWebElement passwordTextfield => driver.FindElement(By.Name("password"));

        public IWebElement mobileTextfield => driver.FindElement(By.Name("mobile"));

        // public List<IWebElement> countryDropdown => driver.FindElements(By.XPath("//li//div"));

        public IWebElement plsSelectCountryBtn => driver.FindElement(By.XPath("//span[text()='Please Select']"));


        public IWebElement countryDropdwn => driver.FindElement(By.XPath("select[name = 'country']"));

        public IWebElement selectParticularCountry => driver.FindElement(By.XPath("//option[text()='Australia']"));
        public IWebElement address1Textfield => driver.FindElement(By.Name("address1"));

        public IWebElement address2Textfield => driver.FindElement(By.Name("address2"));

        public IWebElement submitBtn => driver.FindElement(By.XPath("//button[text()='Submit']"));

        public IWebElement currencyDropdown => driver.FindElement(By.Name("currency"));

        public IWebElement balanceTextfield => driver.FindElement(By.Name("balance"));

        public void AddCustomer()
        {
            try
            {
                firstNameTextfield.SendKeys(TestContext.Parameters.Get("customerFirstName"));
                lastNameTextfield.SendKeys(TestContext.Parameters.Get("customerLastName"));
                emailTextfield.SendKeys(TestContext.Parameters.Get("customerEmail"));
                passwordTextfield.SendKeys(TestContext.Parameters.Get("customerPassword"));
                mobileTextfield.SendKeys("0123456789");
                plsSelectCountryBtn.Click();
                selectParticularCountry.Click();
                BaseClass baseClass = new BaseClass();
                address1Textfield.SendKeys("Bengaluru");
                baseClass.SelectFromDropDownByText(currencyDropdown, "INR");
                balanceTextfield.SendKeys("1200");
                submitBtn.Click();

            }
            catch (Exception e)
            {
                Assert.Fail("Not able to Submit Form");
                driver.Quit();

            }

        }
    }
}
