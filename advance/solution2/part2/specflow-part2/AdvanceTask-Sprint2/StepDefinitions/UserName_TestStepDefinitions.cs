using AdvanceTask_Sprint2.AssertHelpers;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Pages;
using AdvanceTask_Sprint2.Steps;
using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTask_Sprint2.StepDefinitions
{
    [Binding]
    public class UserName_TestStepDefinitions : BaseSetup
    {
        UserNameSteps UserNameStepsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ProfileUserNameComponent ProfileUserNameComponentObj;
        UserNameAssertion UserNameAssertionObj;
        public UserName_TestStepDefinitions()
        {

            UserNameStepsObj = new UserNameSteps();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ProfileUserNameComponentObj = new ProfileUserNameComponent();
            UserNameAssertionObj = new UserNameAssertion();
        }

        [When(@"User able to update the desired Availaility time with data ""([^""]*)""")]
        public void WhenUserAbleToUpdateTheDesiredAvailailityTimeWithData(string AvailabilityJsonPath)
        {

            UserNameStepsObj.AddAvailabilityTime(AvailabilityJsonPath);
        }

        [Then(@"User should see a success message confirming Availability status change")]
        public void WhenUserShouldSeeASuccessMessageConfirmingAvailabilityStatusChange()
        {
            string actualmessage = ProfileUserNameComponentObj .GetMessageBoxText();
            UserNameAssertionObj.AvailabilityAssertion("Availability updated", actualmessage);
        }

        [When(@"User able to update the desired Hours with data ""([^""]*)""")]
        public void WhenUserAbleToUpdateTheDesiredHoursWithData(string AddHoursJsonPath)
        {
            UserNameStepsObj.AddHoursWeek(AddHoursJsonPath);
        }

        [Then(@"User should see a success message confirming Hours status change")]
        public void WhenUserShouldSeeASuccessMessageConfirmingHoursStatusChange()
        {
            string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
            UserNameAssertionObj.HoursAssertion("Availability updated", actualmessage);
        }

        [When(@"User able to update the desired Target with data ""([^""]*)""")]
        public void WhenUserAbleToUpdateTheDesiredTargetWithData(string AddTargetJsonPath)
        {
            UserNameStepsObj.AddEarnTarget(AddTargetJsonPath);
        }

        [Then(@"User should see a success message confirming Target status change")]
        public void WhenUserShouldSeeASuccessMessageConfirmingTargetStatusChange()
        {
            string actualmessage = ProfileUserNameComponentObj.GetMessageBoxText();
            UserNameAssertionObj.EarnTargetAssertion("Availability updated", actualmessage);
        }

        [Then(@"User able to Edit the First and Last Name with data ""([^""]*)""")]
        public void ThenUserAbleToEditTheFirstAndLastNameWithData(string UserFirtLastNameJsonPath)
        {
            UserNameStepsObj.addUserName(UserFirtLastNameJsonPath);
        }
    }
}
