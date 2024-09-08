using AdvanceTaskPart1.Pages;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class LoginSteps
    {
        LoginPage loginPageObj;
        public LoginSteps()
        {
            loginPageObj = new LoginPage();
        }
        public void doLogin()
        {
            LoginModel loginModel = new LoginModel();
            loginModel.setEmail("geothy@gmail.com");
            loginModel.setPassword("7geothy*");
            loginPageObj.clickSignInButton();
            loginPageObj.LoginActions(loginModel);
        }
    }
}
