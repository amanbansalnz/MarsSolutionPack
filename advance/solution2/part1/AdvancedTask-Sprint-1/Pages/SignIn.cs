using Advanced_Task_1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Pages
{
    public class SignIn : BaseSetup
    {
        private IWebElement signInButton;
        public void renderAddComponent()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//a[text()='Sign In']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ClickSignIn()
        {
            renderAddComponent();
            signInButton.Click();
            Thread.Sleep(2000);
        }
    }
}

