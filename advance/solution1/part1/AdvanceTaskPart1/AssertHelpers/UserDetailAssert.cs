using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class UserDetailAssert : CommonDriver
    {
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        static string popupMessage = "Availability updated";
        public static void EditUserDetailAssert()
        {
            string popupMsgBox = popupMsg.Text;
            Thread.Sleep(2000);
            Console.WriteLine(popupMsgBox);
            Assert.That(popupMsgBox, Is.EqualTo(popupMessage));
            if (popupMsgBox == popupMessage)
            {
                test.Log(Status.Pass, "Test Passed User Details Successfully Entered");
            }
        }
    }
}
