using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Pages.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class NotificationSteps
    {
        NotificationPage notificationPageObj;
        public NotificationSteps()
        {
            notificationPageObj = new NotificationPage();
        }
        public void CheckSelectAllNotificationSteps()
        {
            bool selectAllNotification = notificationPageObj.CheckSelectAllNotification();
            NotificationAssert.NotificationAssertSelectAll(selectAllNotification);
        }
        public void CheckUnSelectAllNotificationSteps()
        {
            bool unSelectAllNotification = notificationPageObj.CheckUnSelectAllNotification();
            NotificationAssert.NotificationAssertUnSelectAll(unSelectAllNotification);
        }
        public void DeleteNotificationSteps()
        {
            notificationPageObj.DeleteNotification();
            NotificationAssert.NotificationsAssert();
        }
        public void CheckLoadMoreNotificationSteps()
        {
            bool loadMoreNotification = notificationPageObj.CheckLoadMoreNotification();
            NotificationAssert.NotificationAssertLoadMore(loadMoreNotification);
        }
        public void CheckShowLessNotificationSteps()
        {
            bool showLessNotification = notificationPageObj.CheckShowLessNotification();
            NotificationAssert.NotificationAssertShowLess(showLessNotification);
        }
        public void MarkAsReadSteps()
        {
            notificationPageObj.MarkAsReadNotification();
            NotificationAssert.NotificationsAssert();
        }
    }
}
