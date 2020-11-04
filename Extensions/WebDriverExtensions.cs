using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Diagnostics;
using AutomationFramework.Base;

namespace AutomationFramework.Extensions
{
    public static class WebDriverExtensions
    {

        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri => 
            {
                string state = (string)dri.ExecuteJS("return document.readyState".ToString());
                return state == "complete";
            },10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T,bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }


    }
}
