using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AutomationFramework.Helpers;
using AutomationFramework.Config;

namespace AutomationFramework.Base
{
    public class BaseStep : Base
    {
        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.writeFile("Opened the browser !!!");
        }

    }
}
