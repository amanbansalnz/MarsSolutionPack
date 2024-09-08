using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Steps
{
    public class SkillStep : BaseSetup
    {
        SkillComponent skillComponentObj;
        AddUpdateDeleteSkillComponent addUpdateDeleteSkillComponentObj;    
        public SkillStep()
        {
            skillComponentObj = new SkillComponent();
            addUpdateDeleteSkillComponentObj = new AddUpdateDeleteSkillComponent();
        }
        public void AddSkill(string AddJsonFilePath)
        { 
            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>(AddJsonFilePath);
            foreach (SkillModel skilldata in SkillModellList)
            {
                skillComponentObj.clickAddSkill();
                addUpdateDeleteSkillComponentObj.AddSkills(skilldata);
                Thread.Sleep(2000);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void UpdateSkill(string UpdateJsonFilePath)
        {

            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>(UpdateJsonFilePath);
            foreach (SkillModel skilldata in SkillModellList)
            {
                skillComponentObj.clickUpdateSkill();
                addUpdateDeleteSkillComponentObj.updateSkills(skilldata);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
        public void DeleteSkill(string DeleteJsonFilePath)
        {
            List<SkillModel> SkillModellList = JsonHelper.ReadTestDataFromJson<SkillModel>(DeleteJsonFilePath);
            foreach (SkillModel skilldata in SkillModellList)
            {
                addUpdateDeleteSkillComponentObj.deleteSkill(skilldata);
                string actualmessage = addUpdateDeleteSkillComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
    }
}
