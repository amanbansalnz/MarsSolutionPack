using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class ProfileAboutMeAssert : Base
    {
        ProfileAboutMe profileAboutMeObj;
        public ProfileAboutMeAssert()
        {
            profileAboutMeObj = new ProfileAboutMe();
        }
        public void userVerifyAssertion()
        {
            // Read test data from the JSON file using JsonHelper
            List<ProfileAboutMeTestModel> ProfileUsernameData = JsonHelper.ReadTestDataFromJson<ProfileAboutMeTestModel>("D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation\\JsonData\\ProfileUsernameData.json");
            foreach (var profile in ProfileUsernameData)
            {
                string addedUserName = profileAboutMeObj.getVerifyUsername();
                string expectedUsername = profile.firstName + " " + profile.lastName;
                Assert.AreEqual(expectedUsername, addedUserName, "Actual Username do not match");
            }
        }
        public void userProfileAssertion()
        {
            string message = profileAboutMeObj.getSuccessMessage();
            string expectedMessage = "Availability updated";
            Assert.AreEqual(message, expectedMessage, "actual message and expected message do  match");
        }
    }
}

