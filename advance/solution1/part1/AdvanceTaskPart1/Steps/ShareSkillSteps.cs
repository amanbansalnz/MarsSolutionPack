using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Pages.Components;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class ShareSkillSteps
    {
        ShareSkillPage shareSkillPageObj;
        public ShareSkillSteps()
        {
            shareSkillPageObj = new ShareSkillPage();
        }
        public void AddShareSkillsSteps()
        {
            string addShareSkillFile = "ShareSkillData.json";
            List<ShareSkillModel> AddShareSkillData = JsonUtil.ReadJsonData<ShareSkillModel>(addShareSkillFile);
            foreach (ShareSkillModel shareSkillData in AddShareSkillData)
            {
                shareSkillPageObj.AddShareSkills(shareSkillData);
                try
                {
                    ShareSkillAssert.AddShareSkillAssert(shareSkillData.Title);
                }
                catch (Exception ex)
                {
                    ShareSkillAssert.NegativeShareSkillAssert();
                }
            }
        }
    }
}
