Feature: Notification-Test

As a Skillswap user I would be able to see all the Notifications.
So that able to select delete and mark all the notifications as read. 

@order1
Scenario: 01 - Verify that all notifications are loaded.
	Given User logs into Mars portal
	And User navigates to Profile page
	When User clicks on Notification menu tab
	Then User verify See All button

@order2
Scenario Outline: 02 - Verify that additional notifications are loaded.
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Load More button on Dashboard Page

@order3
Scenario Outline: 03 - Verify that less notifications are loaded.
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Show Less button on Dashboard Page

@order4
Scenario Outline: 04 - Select All notifications
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Select all arrow button on Dashboard Page

@order5
Scenario Outline: 05 - Verify that notifications are unselected
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Unselect all button on Dashboard Page

@order6
Scenario Outline: 06 - Verify that  notifications are Mark As Read
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Mark selection as read button on Dashboard Page

@order7
Scenario Outline: 07 - Verify that selected notifications are Deleted
Given User logs into Mars portal
And User navigates to Profile page
When User selects the Dashboard tab on profile page
Then User verify Delete selection button on Dashboard Page
