using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    [TestFixture]
    public class ProfileUserNameTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        UserNameSteps UserNameStepsObj;
        public ProfileUserNameTest()
        {
            signInObj = new SignIn();
            loginPageObj = new LoginPage();
            UserNameStepsObj = new UserNameSteps();           
        }

        [Test, Order(1), Description("Verify that user first and Last name can be updated.")]
        public void addUserName_Test()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            UserNameStepsObj.addUserName();      
        }

        [Test, Order(2), Description("Verify that user Availability Status can be changed.")]
        public void addAvailability()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            UserNameStepsObj.AddAvailabilityTime();
        }

        [Test, Order(3), Description("Verify that user Hours Status can be changed.")]
        public void addHours()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            UserNameStepsObj.AddHoursWeek();
        }

        [Test, Order(4), Description("Verify that user $Earn Target Status can be changed.")]
        public void addTarget()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            UserNameStepsObj.AddEarnTarget();
        }
    }
}
