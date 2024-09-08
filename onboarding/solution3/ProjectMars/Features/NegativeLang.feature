Feature: 3.NegativeLanguageFeature

Scenario: 01:Adding a Language with an invaild Language code
Given User enter in to Marsportal
When User enter an invalid language code and level '<Language>'and '<Level>'
Then User should see an error message '<Language>' and '<Level>'

Examples: 
|Language|Level|
|en123h   | Basic |
|         | Fluent |
| Tamil | ChooseLanguageLevel |





