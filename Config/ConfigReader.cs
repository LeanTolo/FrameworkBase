using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using AutomationFramework.Base;
using System.Xml.XPath;
using System.IO;

namespace AutomationFramework.Config
{
    public class ConfigReader
    {
        /*using app config
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSettings["AUT"].ToString();
        }
        
        in app config

          <appSettings>
                <add key="AUT" value="http://www.instagram.com"/>
          </appSettings>
         
         */

        public static void SetFrameworkSettings()
        {
            XPathItem aut;
            XPathItem buildname;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem logpath;

            string strFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();


            //Get XML Details and pass it in XPathItem type Variables
            aut = navigator.SelectSingleNode("AutomationFramework/RunSettings/AUT");
            buildname = navigator.SelectSingleNode("AutomationFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("AutomationFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("AutomationFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("AutomationFramework/RunSettings/IsReport");
            logpath = navigator.SelectSingleNode("AutomationFramework/RunSettings/LogPath");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logpath.Value.ToString();

        }



    }
}
