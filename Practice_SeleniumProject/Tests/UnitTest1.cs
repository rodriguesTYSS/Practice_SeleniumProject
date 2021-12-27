using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Practice_SeleniumProject
{
    public class Tester
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.co.in/");
        }

        [Test]
        public void Test1()
        {
            driver.FindElement(By.Name("q")).SendKeys("sachin");
            
            Assert.Pass();
        }
    }
}