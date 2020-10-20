using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationFramework.Base
{
    public static class DriverContext
    {

        private static IWebDriver _driver;

        public static IWebDriver Driver
        {

            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }

        }

    }
}
