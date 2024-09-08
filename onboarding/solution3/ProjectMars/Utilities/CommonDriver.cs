using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Utilities
{
    public class CommonDriver
    {
#pragma warning disable
        public static IWebDriver driver;
        public void Initialize()
        {
            //Defining the browser
            driver = new ChromeDriver();

            //Maximize the window
            driver.Manage().Window.Maximize();
        }
        public void Close()
        {
            driver.Close();
        }
    }
}
