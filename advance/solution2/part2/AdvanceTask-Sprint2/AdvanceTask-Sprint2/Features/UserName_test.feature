Feature: UserName_test

As a Skillswap user I would be able to see the UserName details on the Profile Page.
So that I can change the Availability, Hours, Earn Target status.

@order1
 Scenario: 01 - Edit the Users Availability Status 
Given User logs into Mars portal
And User navigates to Profile page
When User able to update the desired Availaility time with data "<AvailabilityJsonPath>"
Then User should see a success message confirming Availability status change
 Examples:
      | AvailabilityJsonPath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\Availability.json|

@order2
Scenario Outline: 02 - Edit the Users Hours Status 
Given User logs into Mars portal
And User navigates to Profile page
When User able to update the desired Hours with data "<AddHoursJsonPath>"
Then User should see a success message confirming Hours status change
Examples:
      | AddHoursJsonPath                                              |
      |C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\AddHours.json|

@order3
Scenario Outline: 03 - Edit the Users Earn Target Status
Given User logs into Mars portal
And User navigates to Profile page
When User able to update the desired Target with data "<AddTargetJsonPath>"
Then User should see a success message confirming Target status change
Examples: 
   | AddTargetJsonPath                                              |
   | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\AddTarget.json|

@order4
Scenario Outline: 04 - Edit the Users First and Last Name
Given User logs into Mars portal
And User navigates to Profile page
Then User able to Edit the First and Last Name with data "<UserFirtLastNameJsonPath>"
Examples: 
   | UserFirtLastNameJsonPath                                              |
   | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\UserFirstLastName.json|


