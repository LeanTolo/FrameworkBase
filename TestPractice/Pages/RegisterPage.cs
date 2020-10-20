using AutomationFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPractice.Pages
{
    class RegisterPage : BasePage
    {
       
        //[FindsBy(How)]

        public string lnkRegister { get; set; }

        public string txtUserName { get; set; }

        public string txtPassword { get; set; }

        public string btnRegister { get; set; }

    }
}
