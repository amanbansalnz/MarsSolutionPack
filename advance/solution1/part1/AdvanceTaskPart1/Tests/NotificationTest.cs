using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Tests
{
    [TestFixture]
    public class NotificationTest : CommonDriver
    {
        HomePageSteps homePageStepsObj;
        NotificationSteps notificationStepsObj;
        public NotificationTest()
        {
            homePageStepsObj = new HomePageSteps();
            notificationStepsObj = new NotificationSteps();
        }
        [Test, Order(1), Description("This test checks the feature select all in notification")]
        public void TestSelectAll()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.CheckSelectAllNotificationSteps();
        }
        [Test, Order(2), Description("This test checks the feature unselect all in notification")]
        public void TestUnSelectAll()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.CheckUnSelectAllNotificationSteps();
        }
        [Test, Order(3), Description("This test checks the Load more feature in notification")]
        public void TestLoadMore()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.CheckLoadMoreNotificationSteps();
        }
        [Test, Order(4), Description("This test checks the Load more feature in notification")]
        public void TestShowLess()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.CheckShowLessNotificationSteps();
        }
        [Test, Order(5), Description("This test makes notification as read")]
        public void TestMarkAsReadNotification()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.MarkAsReadSteps();
        }
        [Test, Order(6), Description("This test deletes notification")]
        public void TestDeleteNotification()
        {
            homePageStepsObj.clickOnNotificationPanel();
            notificationStepsObj.DeleteNotificationSteps();
        }
    }
}
