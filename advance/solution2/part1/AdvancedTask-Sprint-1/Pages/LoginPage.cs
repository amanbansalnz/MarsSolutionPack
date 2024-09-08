using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Pages
{
    public class LoginPage : BaseSetup
    {
        private IWebElement emailField;
        private IWebElement passwordField;
        private IWebElement loginButton;
        public void renderAddComponents()
        {
            try
            {
                emailField = driver.FindElement(By.Name("email"));
                passwordField = driver.FindElement(By.Name("password"));
                loginButton = driver.FindElement(By.XPath("//button[text()='Login']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void LoginSteps()
        {
            List<LoginCredentials> credentialsList = JsonHelper.ReadTestDataFromJson<LoginCredentials>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\LoginData.json");
            foreach (LoginCredentials credentials in credentialsList)
            {
                renderAddComponents();
                emailField.SendKeys("ammu.muru279@gmail.com");
                passwordField.SendKeys("mvp123");
                loginButton.Click();
                Thread.Sleep(5000);
            }
        }
    }
}
