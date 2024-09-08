using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages
{
    public class HostPage:Base
    {
#pragma warning disable
        private IWebElement signInButton;
        public void renderComponents()
        {
            signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));
        }
        public void clickSignIn()
        {
            renderComponents();
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Sign In']", 10);
            signInButton.Click();
        }
    }
}
