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
    public class DescriptionFeatureStepDefinitions : Base
    {
        private LoginComponentPage loginComponentPageObj = new LoginComponentPage();
        private LoginAssert loginAssertObj = new LoginAssert();
        private DescriptionProcess descriptionProcessObj = new DescriptionProcess();
        private DescriptionAssert descriptionAssertObj = new DescriptionAssert();

        [Given(@"User should be successfully logged with valid credential")]
        public void GivenUserShouldBeSuccessfullyLoggedWithValidCredential()
        {
            loginComponentPageObj.LoginDetails();
            loginAssertObj.LoginAssertion();
        }

        [When(@"Enter user Description using Json File with located at ""([^""]*)""")]
        public void WhenEnterUserDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionData = JsonHelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionData)
            {
                LogScreenshot("AddDescription");
                descriptionProcessObj.AddedDescription(data);
            }
        }

        [Then(@"User Should be successfully Enter the Description\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }

        [When(@"User Update the Description using Json File with located at ""([^""]*)""")]
        public void WhenUserUpdateTheDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionUpdateData = JsonHelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionUpdateData)
            {
                LogScreenshot("UpdateDescription");
                descriptionProcessObj.UpdatedDescription(data);
            }
        }

        [Then(@"User Should be successfully Updated the Description\.")]
        public void ThenUserShouldBeSuccessfullyUpdatedTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
        [When(@"User delete Description using Json File with located at ""([^""]*)""")]
        public void WhenUserDeleteDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionDeleteData = JsonHelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionDeleteData)
            {
                LogScreenshot("DeleteDescription");
                descriptionProcessObj.deleteDescription(data);
            }
        }

        [Then(@"User Should be successfully Deleted the Description\.")]
        public void ThenUserShouldBeSuccessfullyDeletedTheDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }

        [When(@"User Enter Negative Description using Json File with located at ""([^""]*)""")]
        public void WhenUserEnterNegativeDescriptionUsingJsonFileWithLocatedAt(string jsonFilePath)
        {
            string jsonContent = jsonFilePath;
            List<DescriptionTestModel> DescriptionNegativeData = JsonHelper.ReadTestDataFromJson<DescriptionTestModel>(jsonContent);
            foreach (var data in DescriptionNegativeData)
            {
                LogScreenshot("NegativeDescription");
                descriptionProcessObj.NegativeDescri(data);
            }
        }

        [Then(@"User Should be successfully Enter the Negative Description\.")]
        public void ThenUserShouldBeSuccessfullyEnterTheNegativeDescription_()
        {
            descriptionAssertObj.verifyDescriptionAssert();
        }
    }
}
