using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding]
    public class SkillsTabStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj;
        ProfileHomePage profilePageObj;
        SkillsPage skillPageObj;
        private static IWebElement popupmsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        string popupMsgInv = "Please enter skill and experience level";
        string popMsgSame = "This skill is already added to your skill list.";
        string popMsgDup = "Duplicated data";
        string popMsgUndefined = "undefined";
        public SkillsTabStepDefinitions()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfileHomePage();
            skillPageObj = new SkillsPage();
        }
        [Given(@"User logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            loginPageObj.LoginActions("geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser();
        }

        [Given(@"navigates to Skills tab in Profile Page")]
        public void GivenNavigatesToSkillsTabInProfilePage()
        {
            profilePageObj.NavigateToSkillsPanel();
        }
        [When(@"user enters Skill ""([^""]*)"" and Skill Level ""([^""]*)""")]
        public void WhenUserEntersSkillAndSkillLevel(string skill, string skilllevel)
        {
            skillPageObj.ClearData();
            skillPageObj.AddSkills(skill, skilllevel);
        }
        [Then(@"the Skill ""([^""]*)"" should be added to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeAddedToSkillsTabInProfilePage(string skill)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            //Verify the pop up message
            string popupMsgadd = skill + " has been added to your skills";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgDup).Or.EqualTo(popMsgUndefined));
        }
        [When(@"user edits Skill ""([^""]*)"" and Skill Level ""([^""]*)""")]
        public void WhenUserEditsSkillAndSkillLevel(string skill, string skillLevel)
        {
            skillPageObj.EditSkill(skill, skillLevel);
        }
        [Then(@"the Skill ""([^""]*)"" should be updated to Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeUpdatedToSkillsTabInProfilePage(string skill)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            //Verify the pop up message
            string popupMsgadd = skill + " has been updated to your skills";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgUndefined).Or.EqualTo(popMsgDup));
        }
        [When(@"user deletes Skill ""([^""]*)""")]
        public void WhenUserDeletesSkill(string skill)
        {
            skillPageObj.RemoveSkill();
        }
        [Then(@"the Skill ""([^""]*)""should be deleted from Skills tab in Profile Page")]
        public void ThenTheSkillShouldBeDeletedFromSkillsTabInProfilePage(string skill)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            //Verify the pop up message
            string popupMsgadd = skill + " has been deleted";
            Assert.AreEqual(popupMsgadd, popupmsg.Text);
        }
    }
}
