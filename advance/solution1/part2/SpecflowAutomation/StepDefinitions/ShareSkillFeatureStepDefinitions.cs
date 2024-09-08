using SpecflowAutomation.AssertHelper;
using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.Pages.Components.SignIn;
using SpecflowAutomation.Process;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.StepDefinitions
{
    [Binding]
    public class ShareSkillFeatureStepDefinitions : Base
    {
        private LoginComponentPage loginComponentPageObj = new LoginComponentPage();
        private LoginAssert loginAssertObj = new LoginAssert();
        private ProfileMenuTab profileMenuTabObj = new ProfileMenuTab();
        private ShareSkillProcess shareSkillProcessObj = new ShareSkillProcess();
        private ShareSkillAssert shareSkillAssertObj = new ShareSkillAssert();

        [Given(@"User Successfully Logged in with valid details\.")]
        public void GivenUserSuccessfullyLoggedInWithValidDetails_()
        {
            loginComponentPageObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"User add share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserAddShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillAddData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillAddData)
            {
                LogScreenshot("Add ShareSkill");
                shareSkillProcessObj.addShareSkillDetails(data);
            }
        }
        [Then(@"User Should be successfully added the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyAddedTheShareSkill_()
        {
            profileMenuTabObj.clickManageListingTab();
            shareSkillAssertObj.addShareSkillAssert();
        }


        [When(@"User update the share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateTheShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareskillUpdateData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareskillUpdateData)
            {
                LogScreenshot("Updated ShareSkill");
                shareSkillProcessObj.shareSkillUpdate(data);
            }
        }
        [Then(@"User Should be successfully updated the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyUpdatedTheShareSkill_()
        {
            shareSkillAssertObj.shareSkillUpdateAssert();
        }


        [When(@"User delete the share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserDeleteTheShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillDelete = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillDelete)
            {
                string title = data.title;
                LogScreenshot("Deleted ShareSkill");
                shareSkillProcessObj.shareSkillDeleteProcess(title);
            }
        }
        [Then(@"User Should be successfully Deleted the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyDeletedTheShareSkill_()
        {
            shareSkillAssertObj.DeleteShareSkillAssert();
        }


        [When(@"User add negative share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserAddNegativeShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillAddNegativeData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillAddNegativeData)
            {
                LogScreenshot("Add Negative ShareSkill");
                shareSkillProcessObj.negativeAddShareSkillProcess(data);
            }
        }
        [Then(@"User Should be successfully got the error message while added negative the ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageWhileAddedNegativeTheShareSkill_()
        {
            shareSkillAssertObj.negativeAddShareSkillAssert();
        }
    

        [When(@"User update negative share skill  using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateNegativeShareSkillUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<ShareSkillTestModel> ShareSkillUpdateNegativeData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(jsonContent);
            foreach (var data in ShareSkillUpdateNegativeData)
            {
                LogScreenshot("Updated Negative ShareSkill");
                shareSkillProcessObj.negativeShareskillUpdateProcess(data);
            }
        }
        [Then(@"User Should be successfully got the error message while Updated negative ShareSkill\.")]
        public void ThenUserShouldBeSuccessfullyGotTheErrorMessageWhileUpdatedNegativeShareSkill_()
        {
            shareSkillAssertObj.negativeShareskillUpdateAssert();
        }
    }
}
