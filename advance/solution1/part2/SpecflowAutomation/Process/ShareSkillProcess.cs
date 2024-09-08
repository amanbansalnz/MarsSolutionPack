using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.Pages.Components.ServiceListingOverview;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Process
{
    public class ShareSkillProcess:Base
    {
#pragma warning disable
        ShareSkillComponent shareSkillComponentObj;
        ProfileMenuTab profileMenuTabObj;
        ManageListingComponent manageListingComponentObj;
        public ShareSkillProcess()
        {
            shareSkillComponentObj = new ShareSkillComponent();
            profileMenuTabObj = new ProfileMenuTab();
            manageListingComponentObj = new ManageListingComponent();
        }
        public void addShareSkillDetails(ShareSkillTestModel addSkill)
        {
            profileMenuTabObj.clickManageListing();
            shareSkillComponentObj.clearExistingData();
            profileMenuTabObj.clickShareSkillTab();
            shareSkillComponentObj.newShareSkill(addSkill);
        }
        public void shareSkillUpdate(ShareSkillTestModel addSkill)
        {
            profileMenuTabObj.clickManageListing();
            profileMenuTabObj.clickManageListingEditIcon();
            shareSkillComponentObj.EditShareSkill(addSkill);
        }
        public void shareSkillDeleteProcess(string Category)
        {
            profileMenuTabObj.clickManageListing();
            manageListingComponentObj.deleteShareSkill(Category);
        }
        public void negativeAddShareSkillProcess(ShareSkillTestModel addSkill)
        {
            profileMenuTabObj.clickManageListing();
            shareSkillComponentObj.clearExistingData();
            profileMenuTabObj.clickShareSkillTab();
            shareSkillComponentObj.shareSkillAddNegative(addSkill);
        }
        public void negativeShareskillUpdateProcess(ShareSkillTestModel addSkill)
        {
            profileMenuTabObj.clickManageListing();
            profileMenuTabObj.clickManageListingEditIcon();
            shareSkillComponentObj.shareSkillUpdateNegative(addSkill);
        }
    }
}
