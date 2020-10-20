using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace AutomationFramework.Base
{
    public abstract class BasePage
    {

        public BasePage()
        {
            //this generate a none dependency of the initialize on the pages
            PageFactory.InitElements(DriverContext.Driver, this);

        }

    }
}
