using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class SkillSteps
    {
        ProfileMenuTab profileMenuTabObj;
        ProfileTabSkills profileTabSkillsObj;
        public SkillSteps()
        {
            profileMenuTabObj = new ProfileMenuTab();
            profileTabSkillsObj = new ProfileTabSkills();
        }
        public void AddSkillSteps()
        {
            string addSkillFile = "AddSkillData.json";
            List<SkillModel> AddSkillData = JsonUtil.ReadJsonData<SkillModel>(addSkillFile);
            foreach (var item in AddSkillData)
            {
                string skill = item.AddSkill;
                string skillLevel = item.ChooseSkill;
                profileTabSkillsObj.AddSkills(skill, skillLevel);
                SkillsAssertHelper.AddSkillsAssert(skill);
            }
        }
        public void EditSkillSteps()
        {
            AddSkillSteps();
            string editSkillFile = "EditSkillData.json";
            List<SkillModel> EditSkillData = JsonUtil.ReadJsonData<SkillModel>(editSkillFile);
            foreach (var item in EditSkillData)
            {
                string eskill = item.AddSkill;
                string eskillLevel = item.ChooseSkill;
                profileTabSkillsObj.EditSkill(eskill, eskillLevel);
                SkillsAssertHelper.EditSkillsAssert(eskill);
            }
        }
        public void DeleteSkillSteps()
        {
            string deleteSkillFile = "DeleteSkillData.json";
            List<SkillModel> DeleteSkillData = JsonUtil.ReadJsonData<SkillModel>(deleteSkillFile);
            foreach (var item in DeleteSkillData)
            {
                string dskill = item.AddSkill;
                string dskillLevel = item.ChooseSkill;
                profileTabSkillsObj.AddSkills(dskill, dskillLevel);
                profileTabSkillsObj.DeleteSkill(dskill, dskillLevel);
                SkillsAssertHelper.DeleteSkillsAssert(dskill);
            }
        }
    }
}
