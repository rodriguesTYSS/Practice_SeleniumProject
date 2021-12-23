using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_SeleniumProject.PageObjects
{
    internal class DashboardPage
    {
        //a[contains(text(),'Accounts')]
        private List<IWebElement> dashboardoptions;

        //li//a[contains(@href,'admins')]
        private IWebElement adminsInAccounts;

        //li//a[contains(@href,'suppliers')]
        private IWebElement adminsInAccounts;

        //li//a[contains(@href,'agents')]
        private IWebElement adminsInAccounts;
    }
}
