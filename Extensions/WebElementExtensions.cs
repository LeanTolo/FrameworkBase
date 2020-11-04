using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using AutomationFramework.Base;

namespace AutomationFramework.Extensions
{
    public static class WebElementExtensions
    {

        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement dropDownList = new SelectElement(element);
            return dropDownList.AllSelectedOptions.First().ToString();       
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement dropDownList = new SelectElement(element);
            return dropDownList.AllSelectedOptions;
        }

        public static void Hover(IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }


        public static void SelectDropDownList(this IWebElement element, string value)
        {

            SelectElement dropDownList = new SelectElement(element);
            dropDownList.SelectByText(value);

        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception(string.Format("Element Not Present Exception"));
            }
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
