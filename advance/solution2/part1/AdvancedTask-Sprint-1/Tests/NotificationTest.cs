using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    [TestFixture]
    public class NotificationTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        NotificationSteps NotificationStepsObj;
        public NotificationTest()
        {
            signInObj = new SignIn();
            loginPageObj = new LoginPage();
            NotificationStepsObj = new NotificationSteps();
        }

        [Test, Order(1), Description("Verify that all notifications are loaded.")]
        public void VerifyNotificationSeeAll()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifySeeAllButton();
        }

        [Test, Order(2), Description("Verify that additional notifications are loaded.")]
        public void VerifyLoadMore()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifyLoadMoreButton();
        }

        [Test, Order(3), Description("Verify that less notifications are loaded.")]
        public void VerifyShowLess()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifyShowLessButton();
        }

        [Test, Order(4), Description("Select All notifications")]
        public void VerifySelectAll()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifySelectAllButton();
        }

        [Test, Order(5), Description("Verify that notifications are unselected")]
        public void VerifyUnSelectAll()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifyUnselectAllButton();
        }

        [Test, Order(6), Description("Verify that  notifications are Mark As Read")]
        public void VerifyMarkAsRead()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifyMarkAsReadButton();
        }

        [Test, Order(7), Description("Verify that selected notifications are Deleted")]
        public void VerifyDelete()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            NotificationStepsObj.VerifyDeleteButton();
        }
    }
}
