using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class ShareSkillAssert : CommonDriver
    {
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement newShareSkill => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        static string addedSkill;
        static string popupMsgInv = "Please complete the form correctly.";
        static string popupMsgValid = "Service Listing Added successfully";
        public static void AddShareSkillAssert(string title)
        {
            Thread.Sleep(2000);
            addedSkill = newShareSkill.Text;
            Assert.That(addedSkill, Is.EqualTo(title));
            test.Log(Status.Pass, "ShareSkill Added Successfully");
            Console.WriteLine("ShareSkill Added Successfully");
        }
        public static void NegativeShareSkillAssert()
        {
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgInv));
            test.Log(Status.Fail, "Please complete the form correctly.");
        }
    }
}
