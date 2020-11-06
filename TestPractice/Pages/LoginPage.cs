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
    class LoginPage : BasePage
    {

        IWebElement txtUserName => DriverContext.Driver.FindElement(By.XPath("//input[@name='username']"));

        IWebElement txtPassword => DriverContext.Driver.FindElement(By.XPath("//input[@name='password']"));

        IWebElement btnLogin => DriverContext.Driver.FindElement(By.XPath("//button[@type='submit']"));


        public void Login(string userName, string password)
        {
            System.Threading.Thread.Sleep(3000);

            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnLogin.Click();

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
