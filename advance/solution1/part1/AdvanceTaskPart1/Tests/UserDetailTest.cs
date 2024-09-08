using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Tests
{
    [TestFixture]
    public class UserDetailTest : CommonDriver
    {
        ProfileMenuTab profileMenuTabObj;
        UserDetailSteps userDetailStepsObj;
        public UserDetailTest()
        {
            profileMenuTabObj = new ProfileMenuTab();
            userDetailStepsObj = new UserDetailSteps();
        }
        [Test, Order(1), Description("This test edits the user details")]
        public void TestUserData()
        {
            userDetailStepsObj.EnterUserDetails();
        }
    }
}
