using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTask_Sprint2.AssertHelpers;

namespace AdvanceTask_Sprint2.Steps
{
    public class NotificationSteps : BaseSetup
    {
        NotificationsComponents NotificationsComponentsObj;
        NotificationAssertion NotificationAssertionObj;
        public NotificationSteps()
        {
            NotificationsComponentsObj = new NotificationsComponents();
            NotificationAssertionObj = new NotificationAssertion();
        }
        public void VerifySeeAllButton()
        {          
            bool isSeeAllClicked = NotificationsComponentsObj.VerifyClickSeeAll();
            NotificationAssertionObj.AssertNotificationSeeAll(isSeeAllClicked);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifyLoadMoreButton()
        {          
            bool isLoadMoreClicked = NotificationsComponentsObj.VerifyClickLoadMore();
            NotificationAssertionObj.AssertLoadMore(isLoadMoreClicked);
        }
        public void VerifyShowLessButton()
        {     
            bool isShowLessClicked = NotificationsComponentsObj.VerifyClickShowLess();
            Thread.Sleep(3000);
            NotificationAssertionObj.AssertShowLess(isShowLessClicked);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifySelectAllButton()
        {
          
            bool isNotificationSelected = NotificationsComponentsObj.VerifyClickSelectAll();
            Thread.Sleep(3000);
           NotificationAssertionObj.AssertSelectAll(isNotificationSelected);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifyUnselectAllButton()
        {
            
            bool isNotificationunselected = NotificationsComponentsObj.VerifyClickUnselectAll();
            Thread.Sleep(3000);
            NotificationAssertionObj.AssertUnselectAll(isNotificationunselected);
            Console.WriteLine("Verification is successful.");
        }
        public void VerifyMarkAsReadButton()
        {         
            bool isMarkSelectionAsRead = NotificationsComponentsObj.VerifyMarkSelectionAsRead();
            string actualmessage = NotificationsComponentsObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);
           NotificationAssertionObj.AssertMarkAsread(isMarkSelectionAsRead);
        }
        public void VerifyDeleteButton()
        {
           
            bool isSelectionDeleted = NotificationsComponentsObj.VerifyDeleteSelectionButton();
            string actualmessage = NotificationsComponentsObj.GetMessageBoxText();
            Console.WriteLine(actualmessage);
           NotificationAssertionObj.AssertDeleteSelection(isSelectionDeleted);

        }
    }
}


