using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class SkillsAssertHelper : CommonDriver
    {
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        static string popupMsgInv = "Please enter skill and experience level";
        static string popMsgSame = "This skill is already exist in your skill list.";
        static string popupMsgEditSame = "This skill is already added to your skill list.";
        static string popMsgDup = "Duplicated data";
        static string popupNoSkill = "has been added to your skills";
        static string popupNoEditSkill = "has been updated to your skills";
        static string popMsgUndefined = "undefined";
        static string popupMsgDel = "has been deleted";
        public static void AddSkillsAssert(String skill)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(1000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popupMsgadd = skill + " has been added to your skills";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popupNoSkill).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgDup));
            Thread.Sleep(1000);
            if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popMsgSame) || (popupMsgBox == popMsgDup))
            {
                test.Log(Status.Info, "Entered Invalid data -> " + popupMsgBox);
                cancelButton.Click();
            }
            else if (popupMsgBox == popupMsgadd || popupMsgBox == popupNoSkill)
            {
                test.Log(Status.Pass, "Adding Test Passed Valid Skills Data Entered");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
        public static void EditSkillsAssert(String skill)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(1000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popupMsgedit = skill + " has been updated to your skills";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgedit).Or.EqualTo(popupMsgInv).Or.EqualTo(popupNoEditSkill).Or.EqualTo(popupMsgEditSame).Or.EqualTo(popMsgDup));
            Thread.Sleep(1000);
            if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popupMsgEditSame) || (popupMsgBox == popMsgDup))
            {
                test.Log(Status.Info, "Entered Invalid data -> " + popupMsgBox);
                cancelButton.Click();
            }
            else if (popupMsgBox == popupMsgedit || popupMsgBox == popupNoEditSkill)
            {
                test.Log(Status.Pass, "Editing Test Passed Valid Skills Data Entered");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
        public static void DeleteSkillsAssert(String skill)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(1000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popUpMsgdel = skill + " has been deleted";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popUpMsgdel).Or.EqualTo(popupMsgDel));
            if ((popupMsgBox == popUpMsgdel) || (popupMsgBox == popupMsgDel))
            {
                test.Log(Status.Pass, "Deleting Test Passed Deletion Successfull");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
    }
}
