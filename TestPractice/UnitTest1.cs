using System;
using AutomationFramework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace TestPractice
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("");


        }
    }
}
