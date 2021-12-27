using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Practice_SeleniumProject.CustomMethods;
using Practice_SeleniumProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.Tests
{
    public class CustomerTest
    {
        IWebDriver driver;
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void AddNewCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            DashboardPage dashboardPage = new DashboardPage(driver);
            BaseClass baseClass = new BaseClass();
            baseClass.ActionHoverAndClick(driver, dashboardPage.accountsLink, dashboardPage.customersInAccounts);
            //Click Add Customer Button
            CustomerManagementPage cmp = new CustomerManagementPage(driver);
            cmp.addCustomerBtn.Click();
            //Add Customer
            AddCustomerPage acp = new AddCustomerPage(driver);
            acp.AddCustomer();
            //Verify Customer Created
            IWebElement verifyCustomer = driver.FindElement(By.XPath("//td[text()=" + "'" + TestContext.Parameters.Get("customerFirstName") + "']"));
            Assert.IsTrue(AssertClass.IsElementPresent(driver, verifyCustomer), "Customer not created or found on customer management page");
        }

        [Test]
        public void DeleteCustomerTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            //Navigate To Customer Management Page
            DashboardPage dashboardPage = new DashboardPage(driver);
            BaseClass baseClass = new BaseClass();
            baseClass.ActionHoverAndClick(driver, dashboardPage.accountsLink, dashboardPage.customersInAccounts);
            int customercountBeforeDelete = driver.FindElements(By.XPath("//table[@class='xcrud-list table table-striped table-hover']/tbody/tr")).Count;
            //Delete Customer
            CustomerManagementPage cmp = new CustomerManagementPage(driver);
            cmp.customerCheckbox.Click();
            cmp.deleteSelectCustomerBtn.Click();
            driver.SwitchTo().Alert().Accept();
            baseClass.Thinktime(3);
            int customercountAfterDelete = driver.FindElements(By.XPath("//table[@class='xcrud-list table table-striped table-hover']/tbody/tr")).Count;
            Assert.IsTrue(customercountBeforeDelete > customercountAfterDelete, "Customer present page");
        }
    }
}

