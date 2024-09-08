Feature: ShareSkill_Test

As a Skillswap user I would be able to show what Skills I know.
So that the people seeking for Skills can look at what details I hold.

@order1
Scenario: 01 - Delete an existing Share Skills from the manage listings
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Manage Listings tab
When User deletes the skills from the Manage Listings
Then User should see a deleted success message confirming the deletion

@order2
Scenario Outline: 02 - Add new Share kills
Given User logs into Mars portal
And User navigates to Profile page
When User clicks on Share Skill button
Then User adds a new Share Skills with data "<AddShareSkillJsonPath>"
 Examples:
      | AddShareSkillJsonPath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\AddShareSkill.json|

@order3
Scenario Outline: 03 - Update Share Skills
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Manage Listings tab
Then User Updates a Skill from Manage Listings with data "<UpdateShareSkillJsonPath>"
Examples:
      | UpdateShareSkillJsonPath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\UpdateShareSkill.json|

@order4
Scenario Outline: 04 - Delete ShareSkill from the list 
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Manage Listings tab
When User deletes the skills from the Manage Listings
Then User should see a deleted success message confirming the deletion