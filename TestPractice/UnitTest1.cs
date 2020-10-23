using System;
using AutomationFramework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TestPractice.Pages;

namespace TestPractice
{
    [TestClass]
    public class UnitTest1 : Base
    {

        string url = "http://www.mercadolibre.com.ar";

        public void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {

            DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("");

            CurrentPage = GetInstance<RegisterPage>();

            CurrentPage.As<RegisterPage>().Register("username","password");

            //page.Register("user", "pass");


        }
    }
}
