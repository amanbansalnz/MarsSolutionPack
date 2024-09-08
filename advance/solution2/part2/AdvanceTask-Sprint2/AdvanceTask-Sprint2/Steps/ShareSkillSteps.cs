using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_Sprint2.AssertHelpers;

namespace AdvanceTask_Sprint2.Steps
{
    public class ShareSkillSteps : BaseSetup
    {
        ProfilePageTabsComponents ProfilePageTabsComponentsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ShareSkillComponent ShareSkillComponentObj;
        ShareSkillAssertion ShareSkillAssertionObj;
        public ShareSkillSteps()
        {
            ProfilePageTabsComponentsObj = new ProfilePageTabsComponents();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ShareSkillComponentObj = new ShareSkillComponent();
            ShareSkillAssertionObj = new ShareSkillAssertion();
        }
        public void AddShareSkill(string AddShareSkillJsonPath)
        {
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>(AddShareSkillJsonPath);
            foreach (ShareSkillModel addShareSkill in ShareSkillModelList)
            {
                ShareSkillComponentObj.AddSkill(addShareSkill);
                ShareSkillAssertionObj.AddShareSkillAssert(addShareSkill);
            }
        }
        public void UpdateShareSkill(string UpdateShareSkillJsonPath)
        {

            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>(UpdateShareSkillJsonPath);
            foreach (ShareSkillModel updateShareSkill in ShareSkillModelList)
            {
                profileTabPageStepsObj.clickUpdateShareSkillIcon();
                Thread.Sleep(3000);
                ShareSkillComponentObj.UpdateSkill(updateShareSkill);
                ShareSkillAssertionObj.UpdatedShareSkillAssertion(updateShareSkill);
            }
        }
        public void DeleteShareSkill()
        {
            ShareSkillComponentObj.DeleteShareSkill();
            string actualmessage = ShareSkillComponentObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);        
        }

    }
}
