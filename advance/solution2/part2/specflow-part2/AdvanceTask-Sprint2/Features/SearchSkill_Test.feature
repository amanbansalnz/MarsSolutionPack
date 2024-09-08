Feature: SearchSkill_Test

As a Skillswap user I would be able to Search the Skills I want to learn.
So that I can seek for Skills that others users hold.

@order1
Scenario: 01 - Verify User able to Serach by Skill Name
Given User logs into Mars portal
And User navigates to Profile page
When User searches for skills with data "<SearchSkillJsonPath>"
Then User should be able to see a list of skills related to the search
 Examples:
      | SearchSkillJsonPath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\SearchSkill.json|


@order2
Scenario Outline: 02 - Verify User able to Serach by User Name
Given User logs into Mars portal
And User navigates to Profile page
When User searches by Usernames with data "<SearchbyUserNameJsonPath>"
Then User should see a list of users with matching usernames
Examples:
      | SearchbyUserNameJsonPath                                              |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\SearchByUserName.json|


@order3
Scenario Outline: 03 - Verify User able to Serach by Category
Given User logs into Mars portal
And User navigates to Profile page
When User searches by Category with data "<SearchbyCategoryJsonPath>"
Then User should see a list of skills in that category
Examples:
      | SearchbyCategoryJsonPath                                              |
      |C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\CategoryData.json|


@order4
Scenario Outline: 04 - Verify User able to Serach by using Filter option 
Given User logs into Mars portal
And User navigates to Profile page
When User searches using filters with data "<SearchByFilterJsonPath>"
Then User should see a refined list based on the applied filters
Examples:
      | SearchByFilterJsonPath                                              |
      |C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\FilterData.json|
