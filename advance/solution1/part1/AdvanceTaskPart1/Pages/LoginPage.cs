using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Pages
{
    public class LoginPage : CommonDriver
    {
        private static IWebElement usernameTextbox;
        private static IWebElement passwordTextbox;
        private static IWebElement logInButton;
        private static IWebElement signInButton;

        public void renderSignInComponents()
        {
            try
            {
                signInButton = driver.FindElement(By.XPath("//*[text()='Sign In']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickSignInButton()
        {
            renderSignInComponents();
            signInButton.Click();
        }
        public void renderLoginComponents()
        {
            try
            {
                usernameTextbox = driver.FindElement(By.XPath("//input[@name='email']"));
                passwordTextbox = driver.FindElement(By.XPath("//input[@name='password']"));
                logInButton = driver.FindElement(By.XPath("//button[text()='Login']"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public void LoginActions(LoginModel loginModel)
        {
            renderLoginComponents();
            usernameTextbox.SendKeys(loginModel.getEmail());
            passwordTextbox.SendKeys(loginModel.getPassword());
            logInButton.Click();
            Thread.Sleep(3000);
        }
    }
}
