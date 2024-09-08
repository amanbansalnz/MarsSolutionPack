using SpecflowAutomation.AssertHelper;
using SpecflowAutomation.Pages.Components.SignIn;
using SpecflowAutomation.Process;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class ProfileAboutMeFeatureStepDefinitions:Base
    {
        private LoginComponentPage loginComponentPageObj = new LoginComponentPage();
        private LoginAssert loginAssertObj = new LoginAssert();
        private ProfileAboutMeProcess profileAboutMeProcessObj = new ProfileAboutMeProcess();
        private ProfileAboutMeAssert profileAboutMeAssertObj = new ProfileAboutMeAssert();

        [Given(@"User should be successfully logged with valid credentials")]
        public void GivenUserShouldBeSuccessfullyLoggedWithValidCredentials()
        {
            loginComponentPageObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"Enter the User Firstname and Lastname details from the json file located at ""([^""]*)""")]
        public void WhenEnterTheUserFirstnameAndLastnameDetailsFromTheJsonFileLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileUserData = JsonHelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileUserData)
            {
                LogScreenshot("UserName");
                profileAboutMeProcessObj.updateUsername(data);
            }
        }
        [Then(@"User should be successfully enter the name")]
        public void ThenUserShouldBeSuccessfullyEnterTheName()
        {
            profileAboutMeAssertObj.userVerifyAssertion();
        }


        [When(@"Enter the user availability using Json file with located at ""([^""]*)""")]
        public void WhenEnterTheUserAvailabilityUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileAvailabilitydata = JsonHelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileAvailabilitydata)
            {
                LogScreenshot("Availability Type");
                profileAboutMeProcessObj.updateAvailabilityType(data);
            }

        }
        [Then(@"User should be successfully Enter the Availability Type")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityType()
        {
            profileAboutMeAssertObj.userProfileAssertion();
        }


        [When(@"Enter the user availability hours using Json file with located at ""([^""]*)""")]
        public void WhenEnterTheUserAvailabilityHoursUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileHoursdata = JsonHelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileHoursdata)
            {
                LogScreenshot("Availability Hours");
                profileAboutMeProcessObj.updateAvailabilityHours(data);
            }
        }
        [Then(@"User should be successfully enter the availability hours")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityHours()
        {
            profileAboutMeAssertObj.userProfileAssertion();
        }


        [When(@"Enter the user availability earnTarget using Jsonfile with located at ""([^""]*)""")]
        public void WhenEnterTheUserAvailabilityEarnTargetUsingJsonfileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ProfileAboutMeTestModel> ProfileEarnTargetdata = JsonHelper.ReadTestDataFromJson<ProfileAboutMeTestModel>(jsonContent);
            foreach (var data in ProfileEarnTargetdata)
            {
                LogScreenshot("Availability EarnTarget");
                profileAboutMeProcessObj.updateAvailabilityEarnTarget(data);
            }
        }
        [Then(@"User should be successfully enter the  availability earnTarget")]
        public void ThenUserShouldBeSuccessfullyEnterTheAvailabilityEarnTarget()
        {
            profileAboutMeAssertObj.userProfileAssertion();
        }
    }
}
