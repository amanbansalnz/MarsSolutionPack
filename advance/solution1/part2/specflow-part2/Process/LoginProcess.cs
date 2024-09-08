using SpecflowAutomation.Pages.Components.SignIn;
using SpecflowAutomation.Pages;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using SpecflowAutomation.TestModel;

namespace SpecflowAutomation.Process
{
    public class LoginProcess:Base
    {
#pragma warning disable
       
        LoginComponent loginComponentObj;
        JsonHelper jsonHelperObj;
        public LoginProcess()
        {
            loginComponentObj = new LoginComponent();
            jsonHelperObj = new JsonHelper();
        }
        public void doLogin(LoginTestModel data)
        {
          loginComponentObj.validLogin(data);
        }
        public void invalidUsernameProcess(LoginTestModel data)
        {
            loginComponentObj.invalidUsernameValidPassword(data);
        }
        public void InvalidPassProcess(LoginTestModel data)
        {
            loginComponentObj.validUserInvalidPassword(data);
        }
    }
}
