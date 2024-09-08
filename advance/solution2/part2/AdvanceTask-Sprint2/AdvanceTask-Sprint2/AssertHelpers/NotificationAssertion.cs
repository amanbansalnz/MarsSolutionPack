using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.AssertHelpers
{
    public class NotificationAssertion
    {
        NotificationsComponents NotificationsComponentsObj;
        ProfileTabPageSteps ProfileTabPageStepsObj;
        public NotificationAssertion()
        {
            NotificationsComponentsObj = new NotificationsComponents();
            ProfileTabPageStepsObj = new ProfileTabPageSteps();
        }
        public void AssertNotificationSeeAll(bool isSeeAllClicked)
        {
            Assert.IsTrue(isSeeAllClicked, "Failed to click the 'See All' button for notifications.");
        }
        public void AssertLoadMore(bool isLoadMoreClicked)
        {
            Assert.IsTrue(isLoadMoreClicked, "Failed to click the 'Load More' button for notifications.");
        }
        public void AssertShowLess(bool isShowLessClicked)
        {
            Assert.IsTrue(isShowLessClicked, "Failed to click the 'Show Less' button for notifications.");
        }
        public void AssertSelectAll(bool isSelectAllClicked)
        {
            Assert.IsTrue(isSelectAllClicked, "Failed to click the 'Select All' button for notifications.");
        }
        public void AssertUnselectAll(bool isNotificationunselected)
        {
            Assert.IsTrue(isNotificationunselected, "Failed to click the 'Unselect All' button for notifications.");
        }

        public void AssertMarkAsread(bool isMarkAsreadClicked)
        {
            Assert.IsTrue(isMarkAsreadClicked, "Failed to click the 'Mark As Read' button for notifications.");
        }

        public void AssertDeleteSelection(bool isSelectionDeleted)
        {
            Assert.IsTrue(isSelectionDeleted, "Failed to click the 'Delete Selection' button for notifications.");
        }

    }
}