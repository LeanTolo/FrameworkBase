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

            string fileName = "C:\\Users\\Tolo\\source\\repos\\FrameworkBase\\TestPractice\\Data\\Login.xlsx";
            
            ExcelHelper.PopulateInCollection(fileName);

            CurrentPage = GetInstance<LoginPage>();

           // CurrentPage.As<LoginPage>().Login("lolo_tol_10@hotmail.com", "TestingPass123");
            CurrentPage.As<LoginPage>().Login(ExcelHelper.ReadData(1, "UserName"), ExcelHelper.ReadData(1, "Password"));


            Console.WriteLine("success");
        }
    }
}
