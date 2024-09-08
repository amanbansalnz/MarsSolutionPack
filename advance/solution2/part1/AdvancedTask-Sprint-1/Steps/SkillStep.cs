using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Steps
{
    public class SkillStep : BaseSetup
    {
        SkillComponent skillComponentObj;
        AddUpdateDeleteSkillComponent addUpdateDeleteSkillComponentObj;
        SkillAssertions SkillAssertionsObj;
        public SkillStep()
        {
           
            skillComponentObj = new SkillComponent();

            addUpdateDeleteSkillComponentObj = new AddUpdateDeleteSkillComponent();
            SkillAssertionsObj = new SkillAssertions();
        }
        public void AddSkill()
        {
           
            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddSkill.json");
            foreach (SkillModel skilldata in SkillModellList)
            {
                skillComponentObj.clickAddSkill();
                addUpdateDeleteSkillComponentObj.AddSkills(skilldata);
                Thread.Sleep(2000);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);

                SkillAssertionsObj.AssertAddSkill(skilldata);
            }
        }
        public void UpdateSkill()
        {

            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateSkill.json");
            foreach (SkillModel skilldata in SkillModellList)
            {
                skillComponentObj.clickUpdateSkill();
                addUpdateDeleteSkillComponentObj.updateSkills(skilldata);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
                SkillAssertionsObj.AsserUpdateSkill(skilldata);
            }
        }
        public void DeleteSkill()
        {
            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\DeleteSkill.json");
            foreach (SkillModel skilldata in SkillModellList)
            {
                addUpdateDeleteSkillComponentObj.deleteSkill(skilldata);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
                SkillAssertionsObj.DeleteSkillAssertion();
            }
        }
    }
}
