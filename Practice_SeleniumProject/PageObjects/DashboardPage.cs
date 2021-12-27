using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    public class DashboardPage
    {
        public IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement accountsLink => driver.FindElement(By.XPath("//a[contains(text(),'Accounts')]"));

        public IWebElement cmsLink => driver.FindElement(By.XPath("//a[contains(text(),'CMS')]"));

        public IWebElement carsLink => driver.FindElement(By.XPath("//a[contains(text(),'cars')]"));

        public IWebElement hotelsLink => driver.FindElement(By.XPath("//a[contains(text(),'hotels')]"));
        public IWebElement adminsInAccounts => driver.FindElement(By.XPath("//li//a[contains(@href,'admins')]"));

        public IWebElement suppliersInAccounts => driver.FindElement(By.XPath("//li//a[contains(@href,'suppliers')]"));

        public IWebElement agentsInAccounts => driver.FindElement(By.XPath("//li//a[contains(@href,'agents')]"));

        public IWebElement customersInAccounts => driver.FindElement(By.XPath("//li//a[contains(@href,'customers')]"));
        
        public IWebElement guestCustomersInAccounts => driver.FindElement(By.XPath("//li//a[contains(@href,'guest')]"));

        public IWebElement logoutButton => driver.FindElement(By.XPath("//*[@id='logout']/a"));


    }

}
