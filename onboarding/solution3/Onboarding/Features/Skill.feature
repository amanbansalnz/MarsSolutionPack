Feature: 2.Skill Feature
Scenario: A.Add a Skill to User Profile
Given User Login to MarsPortal Application Successfully
When Create a New Skill into User Profile '<Skill>' and '<Level>'
Then The Skill Record Created '<Skill>' and '<Level>'

Examples: 
| Skill  | Level    |
| C#     | Beginner |
| java   | Beginner |
| SQL    | Beginner |
| Python | Beginner |

Scenario: B.Edit a Existing Skill in User Profile
Given User Able Login Into MarsPortal Application 
When Edit a Existing Skill into User Profile '<Skill>' and '<Level>' Successfully
Then The NewSkill record created '<Skill>' and '<Level>'

Examples: 
| Skill   | Level    |
| Java    | Beginner |
| Selenum | Beginner |

Scenario: C.Delete a Existing Skill in User Profile
Given User Logs Into MarsPortal Application 
When Delete the added Skill

Examples: 
| Skill | Level    |
| Java  | Beginner |
