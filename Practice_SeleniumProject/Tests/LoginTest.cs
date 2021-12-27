
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Practice_SeleniumProject.PageObjects;
using Practice_SeleniumProject.CustomMethods;

namespace Practice_SeleniumProject.Tests
{
    public class LoginTest
    {
        IWebDriver driver;
        public TestContext TestContext { get; set; }
        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("url"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
        [Test]
        public void VerifyValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            string username = TestContext.Parameters.Get("username");
            string password = TestContext.Parameters.Get("password");
            loginPage.LoginApplication(username, password);
            DashboardPage dp = new DashboardPage(driver);
            Assert.IsTrue(AssertClass.IsElementPresent(driver, dp.logoutButton), "User not on home page");

        }
        [Test]
        public void VerifyInValidLoginToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("wrongPassword"));
            System.Threading.Thread.Sleep(4000);
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.invalidError), "No Error Found");

        }
        [Test]
        public void VerifyLogOutToApplication()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginApplication(TestContext.Parameters.Get("username"), TestContext.Parameters.Get("password"));
            System.Threading.Thread.Sleep(1000);
            //IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            //executor.ExecuteScript("document.body.style.zoom = '0.8'");
            DashboardPage dp = new DashboardPage(driver);
            dp.logoutButton.Click();
            BaseClass baseClass = new BaseClass();
            baseClass.Thinktime(3);
            Assert.IsTrue(AssertClass.IsElementPresent(driver, loginPage.loginBtn), "User not redirected to Login page");

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}

