using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement emailTextField => driver.FindElement(By.Name("email"));
        public IWebElement pwdTextField => driver.FindElement(By.Name("password"));
        public IWebElement loginBtn => driver.FindElement(By.XPath("//span[text()='Login']"));
        public IWebElement invalidError => driver.FindElement(By.XPath("//div[text()='Invalid Login Credentials']"));
        public IWebElement forgotPwdLink => driver.FindElement(By.LinkText("Forget Password"));


        public void LoginApplication(string userName, string passWord)
        {
            try
            {
                emailTextField.Clear();
                emailTextField.SendKeys(userName.Trim());
                pwdTextField.Clear();
                pwdTextField.SendKeys(passWord.Trim());
                loginBtn.Click();
            }
            catch (Exception E)
            {
                Console.WriteLine("Test Fail: did not enter username and password  : {0}", E.Message);
                throw;
            }
        }


    }
}
