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
    public class ShareSkillTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        ShareSkillSteps ShareSkillStepsObj;
        ResetShareSkillState ResetShareSkillStateObj;

        public ShareSkillTest()
        {
            signInObj = new SignIn();
            loginPageObj = new LoginPage();
            ShareSkillStepsObj = new ShareSkillSteps();
            ResetShareSkillStateObj = new ResetShareSkillState();
        }

        [Test, Order(1), Description("Verify that user can add new Skill.")]
        public void AddShareSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            ResetShareSkillStateObj.ClickOnManageListing();
            ResetShareSkillStateObj.DeleteAllSkills();
            ShareSkillStepsObj.AddShareSkill();
        }

        [Test, Order(2), Description("Verify that user can update a Skill.")]
        public void UpdateShareSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            ResetShareSkillStateObj.ClickOnManageListing();
            ResetShareSkillStateObj.DeleteAllSkills();
            ShareSkillStepsObj.AddShareSkill();
            ShareSkillStepsObj.UpdateShareSkill();        
        }

        [Test, Order(3), Description("Verify that user can delete a Skill.")]
        public void DeleteShareSkillTest()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            ShareSkillStepsObj.AddShareSkill();
            ShareSkillStepsObj.DeleteShareSkill();
        }
    }
}
