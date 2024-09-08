using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Pages;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    public class LoginTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        Assertions assertions;

        [Test]
        public void LoginSteps_Test()
        {
            SignIn signInObj = new SignIn();
            LoginPage loginPageObj = new LoginPage();
            Assertions assertions = new Assertions();
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            assertions.getUserName();
        }
    }
}
