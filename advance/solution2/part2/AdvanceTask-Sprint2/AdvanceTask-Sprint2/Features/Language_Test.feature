Feature: Language Feature

As a Skillswap user I would be able to show what languages I know.
So that the people seeking for languages can look at what details I hold.
 
Scenario: 01 - Delete an existing Language
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Language tab
When User deletes all the records
Then User should not be able to view the deleted language record

Scenario Outline: 02 - Add new Language
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Language tab
When User adds a new record with language data "<AddJsonFilePath>"
Then Mars portal should save the new Language record 
 Examples:
      | AddJsonFilePath                                                                                                           |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\AddLanguage.json|

Scenario Outline: 03 - Update new Language
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Language tab
When User Updates a new Language record with data "<UpdateJsonFilePath>"
Then Mars portal should save the Updated Language record
 Examples:
      | UpdateJsonFilePath                                                  |
      | C:\AdvnacedTask-Sprint-2\MVP-Advanced-Task-Sprint-2\AdvanceTask-Sprint2\AdvanceTask-Sprint2\JsonDataFiles\UpdateLanguage.json|

Scenario Outline: 04 - Delete Languages from the list 
Given User logs into Mars portal
And User navigates to Profile page
And User selects the Language tab
When User deletes the language records
Then Mars portal should successfully delete the language records



