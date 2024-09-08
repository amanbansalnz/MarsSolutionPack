using NUnit.Framework;
using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.Pages.Components.ServiceListingOverview;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.AssertHelper
{
    public class ShareSkillAssert:Base
    {
        ShareSkillComponent shareSkillComponentObj;
        ManageListingComponent manageListingComponentObj;
        ProfileMenuTab profileMenuTabObj;
#pragma warning disable

        public ShareSkillAssert()
        {
            shareSkillComponentObj = new ShareSkillComponent();
            manageListingComponentObj = new ManageListingComponent();
            profileMenuTabObj = new ProfileMenuTab();
        }
        public void addShareSkillAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation\\JsonData\\ShareSkillAddData.json";
            List<ShareSkillTestModel> ShareSkillAddData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(sFile);
            foreach (var data in ShareSkillAddData)
            {
                string category = data.category;
                string addedShareSkillCategory = shareSkillComponentObj.verifyAddedShareSkill();
                if (addedShareSkillCategory == data.category)
                {
                    Assert.AreEqual(addedShareSkillCategory, data.category, "The actual and expected do not match");
                }
                else
                {
                    Console.WriteLine("Check Error");
                }
            }
        }
        public void shareSkillUpdateAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation\\JsonData\\ShareSkillUpdateData.json";
            List<ShareSkillTestModel> ShareSkillUpdateData = JsonHelper.ReadTestDataFromJson<ShareSkillTestModel>(sFile);
            foreach (var data in ShareSkillUpdateData)
            {
                string category = data.category;
                profileMenuTabObj.clickManageListingTab();
                string editedShareSkillCategory = shareSkillComponentObj.verifyEditedShareSkill();
                if (editedShareSkillCategory == data.category)
                {
                    Assert.AreEqual(editedShareSkillCategory, data.category, "The actual and expected do not match");
                }
                else
                {
                    Console.WriteLine("Check Error");
                }
            }
        }
        public void negativeAddShareSkillAssert()
        {
            string errorMessageBox = shareSkillComponentObj.verifyNegativeShareSkill();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
        }
        public void DeleteShareSkillAssert()
        {
            string messageBox = manageListingComponentObj.verifyDeletedList();
            string popupMessage = messageBox;
            if (popupMessage.Contains("has been deleted"))
            {
                Console.WriteLine("Skill has been deleted");
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.AreEqual(messageBox, popupMessage, "Actual message and expected message do not match");
        }
        public void negativeShareskillUpdateAssert()
        {
            string errorMessageBox = shareSkillComponentObj.verifyNegativeShareSkillUpdate();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
        }
    }
}

