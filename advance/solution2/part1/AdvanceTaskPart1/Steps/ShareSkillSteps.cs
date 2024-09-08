using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Steps
{
    public class ShareSkillSteps : BaseSetup
    {
        ProfilePageTabsComponents ProfilePageTabsComponentsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        ShareSkillComponent ShareSkillComponentObj;
        ShareSkillAssertions ShareSkillAssertionsObj;

        public ShareSkillSteps()
            {
            ProfilePageTabsComponentsObj = new ProfilePageTabsComponents();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            ShareSkillComponentObj = new ShareSkillComponent();
            ShareSkillAssertionsObj = new ShareSkillAssertions();
             }
        public void AddShareSkill()
        {
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddShareSkill.json");
            foreach (ShareSkillModel addShareSkill in ShareSkillModelList)
            {
                profileTabPageStepsObj.clickShareSkill();
                ShareSkillComponentObj.AddSkill(addShareSkill);
                ShareSkillAssertionsObj.AssertSkillTitle(addShareSkill);
            }
        }
        public void UpdateShareSkill()
        {
           
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateShareSkill.json");
            foreach (ShareSkillModel updateShareSkill in ShareSkillModelList)
            {
                profileTabPageStepsObj.clickUpdateShareSkillIcon();
                ShareSkillComponentObj.UpdateSkill(updateShareSkill);
               ShareSkillAssertionsObj.AssertUpdatedSkillTitle(updateShareSkill);
            }
        }
        public void DeleteShareSkill()
        {
            ShareSkillComponentObj.DeleteShareSkill();
            string actualmessage = ShareSkillComponentObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);
            ShareSkillAssertionsObj.AssertDeletedShareSkill();
        }

    }
}
