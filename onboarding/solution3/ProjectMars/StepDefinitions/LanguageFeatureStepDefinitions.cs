using ProjectMars.Utilities;
using ProjectMars.Pages;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Reflection.Emit;
using FluentAssertions;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class LangFeatureStepDefinitions : CommonDriver
    {
        SignInPage SignInPageObj;
        LanguagePage LanguagePageObj;

        public LangFeatureStepDefinitions()
        {
            SignInPageObj = new SignInPage();
            LanguagePageObj = new LanguagePage();
        }

        [Given(@"User Able Login Into MarsPortal Application Successfully")]
        public void GivenUserAbleLoginIntoMarsPortalApplicationSuccessfully()
        {
            SignInPageObj.SignInSteps();
        }


        [When(@"Create a NewLanguage Into User Profile '([^']*)' and '([^']*)'")]
        public void WhenCreateANewLanguageIntoUserProfileAnd(string Language, string Level)
        {
            LanguagePageObj.clearExistingdata();
            LanguagePageObj.AddLanguage(Language, Level);
        }
        [Then(@"The NewLanguage Record Created '([^']*)' and '([^']*)' successfully created")]
        public void ThenTheNewLanguageRecordCreatedAndSuccessfullyCreated(string Language, string Level)
        {

            string Newlanguage = LanguagePageObj.getAddLanguage();
            string Newlevel = LanguagePageObj.getAddLevel();
            Thread.Sleep(1000);
            Assert.AreEqual(Language, Newlanguage, "Actual Language and expected Language Level do not match");
            Assert.AreEqual(Level, Newlevel, "Actual Level and expected Language Level do not match");
        }
        [Given(@"User Logs Into MarsPortal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            SignInPageObj.SignInSteps();
        }
        [When(@"Edit a Existing Language into User Profile '([^']*)' and '([^']*)'")]
        public void WhenEditAExistingLanguageIntoUserProfileAnd(string Language, string Level)
        {
            LanguagePageObj.EditLanguage(Language, Level);
        }

        [Then(@"The NewLanguage Record Created '([^']*)' and '([^']*)' successfully")]
        public void ThenTheNewLanguageRecordCreatedAndSuccessfully(string Language, string Level)
        {
            string createdLanguage = LanguagePageObj.getEditedLanguage();
            string createdLevel = LanguagePageObj.getEditedLevel();
            Thread.Sleep(1000);
            Assert.AreEqual(Language, createdLanguage, "Edited language and expected language do not match.");
            Assert.AreEqual(Level, createdLevel, "Edited level and created level do not match");
        }

        [Given(@"User Logs Into MarsPortal successfully")]
        public void GivenUserLogsIntoMarsPortalSuccessfully()
        {
            SignInPageObj.SignInSteps();
        }


        [When(@"Delete the added language")]
        public void WhenDeleteTheAddedLanguage()
        {
            LanguagePageObj.DeleteLanguage();
        }



    }
}

