using Advanced_Task_1.Utilities;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Task_1.AssertHelpers;

namespace Advanced_Task_1.Steps
{
    public class NotificationSteps : BaseSetup
    {

        NotificationsComponents NotificationsComponentsObj;
        ProfileTabPageSteps ProfileTabPageStepsObj;
        NotificationAssertion NotificationAssertionObj;
        public NotificationSteps()
        {
            NotificationsComponentsObj = new NotificationsComponents();
            ProfileTabPageStepsObj = new ProfileTabPageSteps();
            NotificationAssertionObj = new NotificationAssertion();
        }
        public void VerifySeeAllButton()
        {
            ProfileTabPageStepsObj.clickNotificationmenu();
            bool isSeeAllClicked = NotificationsComponentsObj.VerifyClickSeeAll();
            NotificationAssertionObj.AssertNotificationSeeAll(isSeeAllClicked);
            
        }
        public void VerifyLoadMoreButton()
        {
            ProfileTabPageStepsObj.clickonDashboard();
            bool isLoadMoreClicked = NotificationsComponentsObj.VerifyClickLoadMore();
            Thread.Sleep(3000);
            NotificationAssertionObj.AssertLoadMore(isLoadMoreClicked);
        }
       public void VerifyShowLessButton()
        {
            
          ProfileTabPageStepsObj.clickonDashboard();
          bool isShowLessClicked = NotificationsComponentsObj.VerifyClickShowLess();
          Thread.Sleep(3000);
          NotificationAssertionObj.AssertShowLess(isShowLessClicked);
          Console.WriteLine("Verification is successful.");
           
        }
        public void VerifySelectAllButton()
        {
            ProfileTabPageStepsObj.clickonDashboard();
            bool isNotificationSelected = NotificationsComponentsObj.VerifyClickSelectAll();
            Thread.Sleep(3000);
            NotificationAssertionObj.AssertSelectAll(isNotificationSelected);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifyUnselectAllButton()
        {
            ProfileTabPageStepsObj.clickonDashboard();
            bool isNotificationunselected = NotificationsComponentsObj.VerifyClickUnselectAll();
            Thread.Sleep(3000);
            NotificationAssertionObj.AssertUnselectAll(isNotificationunselected);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifyMarkAsReadButton()
        {
            ProfileTabPageStepsObj.clickonDashboard();
            bool isMarkSelectionAsRead = NotificationsComponentsObj.VerifyMarkSelectionAsRead();
            string actualmessage = NotificationsComponentsObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);
            NotificationAssertionObj.AssertMarkAsread(isMarkSelectionAsRead);

        }
        public void VerifyDeleteButton()
        {
            ProfileTabPageStepsObj.clickonDashboard();
            bool isSelectionDeleted = NotificationsComponentsObj.VerifyDeleteSelectionButton();
            string actualmessage = NotificationsComponentsObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);
            NotificationAssertionObj.AssertDeleteSelection(isSelectionDeleted);

        }
    }
}
