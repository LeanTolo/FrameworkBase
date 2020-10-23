using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomationFramework.Base
{
    public abstract class BasePage : Base
    {
        private RemoteWebDriver _driver;
        public BasePage(RemoteWebDriver driver)
        {
            DriverContext.Driver = driver;

        }

    }
}
