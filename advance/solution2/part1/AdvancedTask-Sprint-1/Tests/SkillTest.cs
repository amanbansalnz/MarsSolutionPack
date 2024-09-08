using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    [TestFixture]
    public class SkillTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ResetState ResetStateObj;
        SkillStep skillStepObj;
      
        public SkillTest()
        {
            signInObj = new SignIn();
            loginPageObj = new LoginPage();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ResetStateObj = new ResetState();
            skillStepObj = new SkillStep();        
        }
        [Test, Order(1), Description("Verify that a Skill and its level can be added.")]
        public void AddSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickSkillsTab();
            Thread.Sleep(3000);
            ResetStateObj.Deleterows();
            skillStepObj.AddSkill();
        }
        [Test, Order(2), Description("Verify that a skill and its level can be updated.")]
        public void UpdateSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickSkillsTab();
            Thread.Sleep(2000);
            ResetStateObj.Deleterows();
            Thread.Sleep(3000);
            skillStepObj.AddSkill();
            skillStepObj.UpdateSkill();
        }
        [Test, Order(3), Description("Verify that a skill and its level can be deleted.")]
        public void DeleteSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickSkillsTab();
            skillStepObj.AddSkill();
            skillStepObj.DeleteSkill();
        }
    }
}