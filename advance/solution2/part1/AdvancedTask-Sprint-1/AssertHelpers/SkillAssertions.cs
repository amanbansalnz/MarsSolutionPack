using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.AssertHelpers
{
    public class SkillAssertions : BaseSetup
    {
        AddUpdateDeleteSkillComponent AddUpdateDeleteSkillComponentObj;

        public SkillAssertions() 
        {
            AddUpdateDeleteSkillComponentObj = new AddUpdateDeleteSkillComponent();
        }
        public void AssertAddSkill(SkillModel skilldata)
        {
            string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddSkill.json");
            string expectedMessage1 = skilldata.skill + " has been added to your skills";
            string expectedMessage2 = "Please enter skill and experience level";
            string expectedMessage3 = "This skill is already exist in your skill list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualmessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
        }

        public void AsserUpdateSkill(SkillModel skilldata)
        {
        string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
        List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateSkill.json");
        string expectedMessage1 = skilldata.skill + " has been updated to your skills";
        string expectedMessage2 = "Please enter skill and experience level";
        string expectedMessage3 = "This skill is already exist to your skill list.";

        Assert.That(actualmessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));
    }

        public string DeleteSkillAssertion()
        {
            string actualmessage = AddUpdateDeleteSkillComponentObj.GetMessageBoxText();
            return actualmessage;
        }

    }
    }


   
