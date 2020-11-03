using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Extensions
{
    public static class StringExtension
    {

        public static string AddSiteExtension(this string siteName)
        {
            return siteName + ".com";
        }

    }
}
