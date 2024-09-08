using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class SignInPage : CommonDriver
    {
        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement EmailAddressTextBox => driver.FindElement(By.Name("email"));
        private IWebElement PasswordTextBox => driver.FindElement(By.Name("password"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void SignInSteps()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            SignInButton.Click();
            Thread.Sleep(1000);

             EmailAddressTextBox.SendKeys("manjujayanthi03@gmail.com");
             PasswordTextBox.SendKeys("manju@rajesh03");
           

            LoginButton.Click();
            Thread.Sleep(3000);
        }
    }
}

