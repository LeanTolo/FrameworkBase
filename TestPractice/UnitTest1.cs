using System;
using AutomationFramework.Base;
using AutomationFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TestPractice.Pages;
using AutomationFramework.Config;
using AutomationFramework.Extensions;

namespace TestPractice
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {

        [TestMethod]
        public void TestMethod1()
        {

            
            

           // CurrentPage = GetInstance<RegisterPage>();

            //CurrentPage.As<RegisterPage>().Register("username","password");

            //page.Register("user", "pass");


        }
    }
}
