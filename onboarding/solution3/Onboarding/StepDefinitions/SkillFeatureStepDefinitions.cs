using NUnit.Framework;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class SkillFeatureStepDefinitions : CommonDriver
    {
        SignInPage SignInPageObj;

        SkillPage SkillPageObj;
        public SkillFeatureStepDefinitions()
        {
            SignInPageObj = new SignInPage();
            SkillPageObj = new SkillPage();
        }
        [Given(@"User Login to MarsPortal Application Successfully")]
        public void GivenUserLoginToMarsPortalApplicationSuccessfully()
        {
            SignInPageObj.SignInSteps();
            SkillPageObj.SkillTabClick();
        }

        [When(@"Create a New Skill into User Profile '([^']*)' and '([^']*)'")]
        public void WhenCreateANewSkillIntoUserProfileAnd(string Skill, string Level)
        {

            SkillPageObj.clearExistingdata();

            SkillPageObj.AddSkill(Skill, Level);
        }

        [Then(@"The Skill Record Created '([^']*)' and '([^']*)'")]
        public void ThenTheSkillRecordCreatedAnd(string Skill, string Level)
        {

            string NewSkill = SkillPageObj.AddSkill();
            string Newlevel = SkillPageObj.AddLevel();

            Assert.AreEqual(Skill, NewSkill, "Actual Skill and expected Skill Level do not match");
            Assert.AreEqual(Level, Newlevel, "Actual Level and expected Skill Level do not match");
        }
        [Given(@"User Able Login Into MarsPortal Application")]
        public void GivenUserAbleLoginIntoMarsPortalApplication()
        {
            SignInPageObj.SignInSteps();
        }

        [When(@"Edit a Existing Skill into User Profile '([^']*)' and '([^']*)' Successfully")]
        public void WhenEditAExistingSkillIntoUserProfileAndSuccessfully(string Skill, string level)
        {
            SkillPageObj.SkillTabClick();
            SkillPageObj.EditSkill(Skill, level);
        }

        [Then(@"The NewSkill record created '([^']*)' and '([^']*)'")]
        public void ThenTheNewSkillRecordCreatedAnd(string skill, string level)
        {
            string CreatedSkill = SkillPageObj.getEditedSkill();
            string Createdlevel = SkillPageObj.getEditedLevel();
            Assert.AreEqual(skill, CreatedSkill, "Edited Skill and expected Skill do not match.");
            Assert.AreEqual(level, Createdlevel, "Edited level and created level do not match");
        }
        [Given(@"User Logs Into MarsPortal Application")]
        public void GivenUserLogsIntoMarsPortalApplication()
        {
            SignInPageObj.SignInSteps();
        }

        [When(@"Delete the added Skill")]
        public void WhenDeleteTheAddedSkill()
        {
            SkillPageObj.SkillTabClick();
            SkillPageObj.DeleteSkill();
        }


    }


}


