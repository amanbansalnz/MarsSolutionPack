Feature: Skill_Test

As a Skillswap user I would be able to show what Skills I know.
So that the people seeking for skills can look at what details I hold.

@order1
 Scenario:  01 - Delete an existing Skill
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Skill tab
When User deletes all the skill records

@order2
Scenario Outline: 02 - Add new Skill
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Skill tab
When User adds a new Skill record with data "<AddJsonFilePath>"
Then User should see a success message confirming the adding skill
 Examples:
      | AddJsonFilePath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\AddSkill.json|

@order3
Scenario Outline: 03 - Updating a Skill
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Skill tab
When User updates a Skill record  with data "<UpdateJsonFilePath>"
Then User should see a success message confirming the updating skill
 Examples:
      | UpdateJsonFilePath                                                  |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\UpdateSkill.json|

@order4
Scenario Outline: 04 - Deleting a Skill
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Skill tab
When User deletes a Skill record with data "<DeleteJsonFilePath>"
Then User should see a success message confirming the deleting skill
 Examples:
      | DeleteJsonFilePath                                                  |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\DeleteSkill.json|





