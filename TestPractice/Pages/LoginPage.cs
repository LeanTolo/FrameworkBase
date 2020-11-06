using AutomationFramework.Base;
using AutomationFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractice.Pages
{
    class LoginPage : Base
    {

        IWebElement txtUserName => DriverContext.Driver.FindElement(By.Id("UserName"));

        IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("Password"));

        IWebElement btnLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"));


        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
        }

        /*
        public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return GetInstance<HomePage>();
        }
        */

        internal void CheckIfLoginExist()
        {
            txtUserName.AssertElementPresent();
        }
    }
}
