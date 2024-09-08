using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.AssertHelpers
{
    public class ShareSkillAssertion : BaseSetup
    {
        public void AddShareSkillAssert(ShareSkillModel addShareSkill)
        {
            IWebElement SkillTitle = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
            string actualSkillTitle = SkillTitle.Text;
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddShareSkill.json");
            string expectedTitle = addShareSkill.title;
            Assert.AreEqual(actualSkillTitle, expectedTitle, "Share skill has been Added successfully ");
            Console.WriteLine($"Skill Title: {actualSkillTitle} has been added sucessfully");
        }

        public void UpdatedShareSkillAssertion(ShareSkillModel updateShareSkill)
        {
            IWebElement UpdatedSkill = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[3]"));
            string UpdatedSkillTitle = UpdatedSkill.Text;
            List<ShareSkillModel> ShareSkillModelList = JsonHelper.ReadTestDataFromJson<ShareSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateShareSkill.json");
            string expectedTitle = updateShareSkill.title;
            Assert.AreEqual(UpdatedSkillTitle, expectedTitle, "Share skill has been Updated successfully ");
            Console.WriteLine($"Skill Title: {UpdatedSkillTitle} has been Updated sucessfully");
        }
        public void AssertDeletedShareSkill()
        {
            ShareSkillComponent ShareSkillComponentObj;
            ShareSkillComponentObj = new ShareSkillComponent();
            string actualMessage = ShareSkillComponentObj.GetMessageBoxText();
            string expectedPattern = @".+ has been deleted";

            // Use a regular expression match to verify the actual message
            bool isMatch = Regex.IsMatch(actualMessage, expectedPattern);
            Assert.IsTrue(isMatch, "Message does not match the expected pattern.");
        }
    }
}
