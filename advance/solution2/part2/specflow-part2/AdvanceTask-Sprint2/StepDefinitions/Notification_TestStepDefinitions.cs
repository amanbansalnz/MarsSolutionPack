using AdvanceTask_Sprint2.AssertHelpers;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Pages;
using AdvanceTask_Sprint2.Steps;
using AdvanceTask_Sprint2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTask_Sprint2.StepDefinitions
{
    [Binding]
    public class Notification_TestStepDefinitions : BaseSetup
    {      
        NotificationSteps NotificationStepsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        NotificationsComponents NotificationsComponentsObj;
        public Notification_TestStepDefinitions()
        {         
            NotificationStepsObj = new NotificationSteps();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            NotificationsComponentsObj = new NotificationsComponents();
        }
        [When(@"User clicks on Notification menu tab")]
        public void WhenUserClicksOnNotificationMenuTab()
        {
            profileTabPageStepsObj.clickNotificationmenu();
            Thread.Sleep(2000);
        }

        [Then(@"User verify See All button")]
        public void ThenUserVerifySeeAllButton()
        {
            NotificationStepsObj.VerifySeeAllButton();
        }

        [When(@"User selects the Dashboard tab on profile page")]
        public void WhenUserSelectsTheDashboardTabOnProfilePage()
        {
            profileTabPageStepsObj.clickonDashboard();
            Thread.Sleep(2000);
        }

        [Then(@"User verify Load More button on Dashboard Page")]
        public void ThenUserVerifyLoadMoreButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifyLoadMoreButton();
        }

        [Then(@"User verify Show Less button on Dashboard Page")]
        public void ThenUserVerifyShowLessButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifyShowLessButton();
        }

        [Then(@"User verify Select all arrow button on Dashboard Page")]
        public void ThenUserVerifySelectAllArrowButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifySelectAllButton();
        }

        [Then(@"User verify Unselect all button on Dashboard Page")]
        public void ThenUserVerifyUnselectAllButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifyUnselectAllButton();
        }

        [Then(@"User verify Mark selection as read button on Dashboard Page")]
        public void ThenUserVerifyMarkSelectionAsReadButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifyMarkAsReadButton();
        }

        [Then(@"User verify Delete selection button on Dashboard Page")]
        public void ThenUserVerifyDeleteSelectionButtonOnDashboardPage()
        {
            NotificationStepsObj.VerifyDeleteButton();

        }
    }
}
