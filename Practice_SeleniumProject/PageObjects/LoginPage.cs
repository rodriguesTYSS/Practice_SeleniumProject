using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    internal class LoginPage
    {
        (name="email")
        private IWebElement emailTextfield;

        name="password"
        private IWebElement pwdTextfield;

        (//span[text()='Login'])
        private IWebElement loginBtn;

        linktext="Forget Password"
        private IWebElement forgotPwdLink;

        

    }
}
