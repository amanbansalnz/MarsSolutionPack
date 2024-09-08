using AdvanceTask_Sprint2.AssertHelpers;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Pages;
using AdvanceTask_Sprint2.Steps;
using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using RazorEngine;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AdvanceTask_Sprint2.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : BaseSetup
    {
        SignIn SignInObj;
        LanguageStep LanguageStepObj;
        LoginPage LoginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ActualState ActualStateObj;
        AssertionLanguage AssertionLanguageObj;
        AddUpdateDeleteLanguageComponent addUpdateDeleteLanguageComponentObj;
        public LanguageFeatureStepDefinitions()
        {
            SignInObj = new SignIn();
            LanguageStepObj = new LanguageStep();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            LoginPageObj = new LoginPage();
            ActualStateObj = new ActualState();
            AssertionLanguageObj = new AssertionLanguage();
            addUpdateDeleteLanguageComponentObj = new AddUpdateDeleteLanguageComponent();
        }

        [Given(@"User logs into Mars portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            SignInObj.ClickSignIn();
        }

        [Given(@"User navigates to Profile page")]
        public void GivenUserNavigatesToProfilePage()
        {
            LoginPageObj.LoginSteps();
        }

        [Given(@"User selects the Language tab")]
        public void GivenUserSelectsTheLanguageTab()
        {
            profileTabPageStepsObj.clickLangaugesTab();
        }

        [When(@"User deletes all the records")]
        public void WhenUserDeletesAllTheRecords()
        {
            ActualStateObj.TableState();
        }

        [Then(@"User should not be able to view the deleted language record")]
        public void ThenUserShouldNotBeAbleToViewTheDeletedLanguageRecord()
        {
            AssertionLanguageObj.assertDeleteLanguage();
        }

        [When(@"User adds a new record with language data ""([^""]*)""")]
        public void WhenUserAddsANewRecordWithLanguageData(string AddJsonFilePath)
        {       
        LanguageStepObj.AddLanguage(AddJsonFilePath);
        }

        [Then(@"Mars portal should save the new Language record")]
        public void ThenMarsPortalShouldSaveTheNewLanguageRecord()
        {          
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            AssertionLanguageObj.AddLanguageAssertion (" has been added to your languages", actualmessage);
        }

        [When(@"User Updates a new Language record with data ""([^""]*)""")]
        public void WhenUserUpdatesANewLanguageRecordWithData(string UpdateJsonFilePath)
        {
            LanguageStepObj.updateLanguage(UpdateJsonFilePath);
        }

        [Then(@"Mars portal should save the Updated Language record")]
        public void ThenMarsPortalShouldSaveTheUpdatedLanguageRecord()
        {
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            AssertionLanguageObj.UpdatedLanguageAssertion(" has been updated to your languages", actualmessage);
        }

        [When(@"User deletes the language records")]
        public void WhenUserDeletesTheLanguageRecords()
        {
            LanguageStepObj.deleteLanguage();

        }

        [Then(@"Mars portal should successfully delete the language records")]
        public void ThenMarsPortalShouldSuccessfullyDeleteTheLanguageRecords()
        {
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            AssertionLanguageObj.DeletedLanguageAssertion(" has been deleted from your languages", actualmessage);
        }
    }
}
