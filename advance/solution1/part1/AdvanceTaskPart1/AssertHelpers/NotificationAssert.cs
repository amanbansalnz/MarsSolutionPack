using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class NotificationAssert : CommonDriver
    {
        private static IWebElement popupMsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        static string popupMessage = "Notification updated";
        public static void NotificationsAssert()
        {
            string popupMsgBox = popupMsg.Text;
            Console.WriteLine(popupMsgBox);
            Assert.That(popupMsgBox, Is.EqualTo(popupMessage));
            if (popupMsgBox == popupMessage)
            {
                test.Log(Status.Pass, "Test Passed");
            }
        }
        public static void NotificationAssertSelectAll(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("Select All Clicked", clicked);
            test.Log(Status.Pass, "SelectAll Clicked :Test Passed");
        }
        public static void NotificationAssertUnSelectAll(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("UnSelect All Clicked", clicked);
            test.Log(Status.Pass, "UnSelect All Clicked :Test Passed");
        }
        public static void NotificationAssertLoadMore(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("Load More Clicked", clicked);
            test.Log(Status.Pass, "Load More Clicked :Test Passed");
        }
        public static void NotificationAssertShowLess(bool clicked)
        {
            Assert.That(clicked, Is.True);
            Console.WriteLine("Show Less Clicked", clicked);
            test.Log(Status.Pass, "Show Less Clicked :Test Passed");
        }
    }
}
