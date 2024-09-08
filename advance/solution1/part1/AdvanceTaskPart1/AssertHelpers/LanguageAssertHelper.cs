using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class LanguageAssertHelper : CommonDriver
    {
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement cancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));
        static string popupMsgInv = "Please enter language and level";
        static string popUpMsgSame = "This language is already exist in your language list.";
        static string popUpMsgEditedSame = "This language is already added to your language list.";
        static string popupNoLang = "has been updated to your languages";
        static string popUpMsgDup = "Duplicated data";
        static string popMsgUndefined = "undefined";

        public static void AddLanguageAssert(String language)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(1000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popupMsgadd = language + " has been added to your languages";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popUpMsgSame).Or.EqualTo(popUpMsgDup));
            Thread.Sleep(1000);
            if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popUpMsgSame) || (popupMsgBox == popUpMsgDup))
            {
                test.Log(Status.Info, "Entered Invalid data -> " + popupMsgBox);
                cancelButton.Click();
            }
            else if (popupMsgBox == popupMsgadd)
            {
                test.Log(Status.Pass, "Test Passed Valid Language Data Entered");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
        public static void EditLanguageAssert(String language)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(2000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popupMsgedit = language + " has been updated to your languages";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgedit).Or.EqualTo(popupNoLang).Or.EqualTo(popupMsgInv).Or.EqualTo(popUpMsgEditedSame).Or.EqualTo(popUpMsgDup));
            Thread.Sleep(1000);
            if ((popupMsgBox == popupMsgInv) || (popupMsgBox == popUpMsgEditedSame) || (popupMsgBox == popUpMsgDup))
            {
                test.Log(Status.Info, "Entered Invalid data -> " + popupMsgBox);
                cancelButton.Click();
            }
            else if (popupMsgBox == popupMsgedit || popupMsgBox == popupNoLang)
            {
                test.Log(Status.Pass, "Test Passed Valid Language Data Updated");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
        public static void DeleteLanguageAssert(String language)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 1000);
            Thread.Sleep(1000);
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            string popUpMsgdel = language + " has been deleted from your languages";
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            Assert.That(popupMsgBox, Is.EqualTo(popUpMsgdel));
            if ((popupMsgBox == popUpMsgdel))
            {
                test.Log(Status.Pass, "Test Passed Deletion Successfull");
            }
            else
            {
                test.Log(Status.Fail, "Test Failed");
            }
        }
    }
}
