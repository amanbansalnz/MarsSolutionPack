using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class LoginPage:CommonDriver
    {
        private readonly By signInButtonLocator = By.XPath("//a[text()='Sign In']");
        IWebElement signInButton;
        private readonly By usernameTextboxLocator = By.XPath("//input[@name='email']");
        IWebElement usernameTextbox;
        private readonly By passwordTextboxLocator = By.XPath("//input[@name='password']");
        IWebElement passwordTextbox;
        private readonly By loginButtonLocator = By.XPath("//button[text()='Login']");
        IWebElement logInButton;
        public void LoginActions(string username, string password)
        {
            
            //Launch Turnup Portal & Navigate to Login Page
            string baseURL = "http://localhost:5000/";
            driver.Navigate().GoToUrl(baseURL);
            //Identify Signin Button & Click on Signin Button
            signInButton = driver.FindElement(signInButtonLocator);
            signInButton.Click();
            //Identify Username textbox & enter valid username
            usernameTextbox = driver.FindElement(usernameTextboxLocator);
            usernameTextbox.SendKeys(username);
            //Identify Password textbox & enter valid password
            passwordTextbox = driver.FindElement(passwordTextboxLocator);
            passwordTextbox.SendKeys(password);
            //Identify Login Button & Click on Login Button
            logInButton = driver.FindElement(loginButtonLocator);
            logInButton.Click();
        }
    }
}
