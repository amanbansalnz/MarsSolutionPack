using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Tests
{
    [TestFixture]
    public class SkillsTest : CommonDriver
    {
        HomePageSteps homePageStepsObj;
        ProfileMenuTab profileMenuTabObj;
        SkillSteps skillStepsObj;
        public SkillsTest()
        {
            homePageStepsObj = new HomePageSteps();
            profileMenuTabObj = new ProfileMenuTab();
            skillStepsObj = new SkillSteps();
        }
        [Test, Order(1), Description("This test adds a new entry in skills feature")]
        public void TestAddSkills()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickSkillsTab();
            skillStepsObj.AddSkillSteps();
        }
        [Test, Order(2), Description("This test updates the skills feature")]
        public void TestEditSkills()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickSkillsTab();
            skillStepsObj.EditSkillSteps();
        }
        [Test, Order(3), Description("This test deletes the Skills feature")]
        public void TestDeleteLanguage()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickSkillsTab();
            skillStepsObj.DeleteSkillSteps();
        }
    }
}
