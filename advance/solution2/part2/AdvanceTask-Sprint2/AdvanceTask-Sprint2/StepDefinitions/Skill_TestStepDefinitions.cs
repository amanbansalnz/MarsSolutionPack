using AdvanceTask_Sprint2.AssertHelpers;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Steps;
using AdvanceTask_Sprint2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTask_Sprint2.StepDefinitions
{
    [Binding]
    public class Skill_TestStepDefinitions
    {
        ProfileTabPageSteps profileTabPageStepsObj;
        ResetState ResetStateObj;
        SkillStep SkillStepObj;
        SkillAssertion SkillAssertionObj;
        AddUpdateDeleteSkillComponent AddUpdateDeleteSkillComponentObj;
        public Skill_TestStepDefinitions()
        {
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ResetStateObj = new ResetState();
            SkillStepObj = new SkillStep();
            SkillAssertionObj = new SkillAssertion();
            AddUpdateDeleteSkillComponentObj = new AddUpdateDeleteSkillComponent();
        }

        [Given(@"User selects the Skill tab")]
        public void GivenUserSelectsTheSkillTab()
        {
            profileTabPageStepsObj.clickSkillsTab();
        }

        [When(@"User deletes all the skill records")]
        public void WhenUserDeletesAllTheSkillRecords()
        {
            ResetStateObj.DeleteRows();
        }
        [When(@"User adds a new Skill record with data ""([^""]*)""")]
        public void WhenUserAddsANewSkillRecordWithData(string AddJsonFilePath)
        {
            SkillStepObj.AddSkill(AddJsonFilePath);
        }

        [Then(@"User should see a success message confirming the adding skill")]
        public void ThenUserShouldSeeASuccessMessageConfirmingTheAddingSkill()
        {
            string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
            SkillAssertionObj.AddSkillAssertion(" has been added to your skills", actualmessage);
        }
        [When(@"User updates a Skill record  with data ""([^""]*)""")]
        public void WhenUserUpdatesASkillRecordWithData(string UpdateJsonFilePath)
        {
           SkillStepObj.UpdateSkill(UpdateJsonFilePath);
        }

        [Then(@"User should see a success message confirming the updating skill")]
        public void ThenUserShouldSeeASuccessMessageConfirmingTheUpdatingSkill()
        {
            string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
            SkillAssertionObj.UpdatedSkillAssertion(" has been updated to your skills", actualmessage);
        }

        [When(@"User deletes a Skill record with data ""([^""]*)""")]
        public void WhenUserDeletesASkillRecordWithData(string DeleteJsonFilePath)
        {
            SkillStepObj.DeleteSkill(DeleteJsonFilePath);
        }

        [Then(@"User should see a success message confirming the deleting skill")]
        public void ThenUserShouldSeeASuccessMessageConfirmingTheDeletingSkill()
        {
            string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
            SkillAssertionObj.DeletedSkillAssertion(" has been deleted", actualmessage);
        }
    }
}
 