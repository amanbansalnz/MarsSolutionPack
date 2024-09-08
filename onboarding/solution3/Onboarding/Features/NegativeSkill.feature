Feature: NegativeSkill
 
 Scenario: 02:Adding  a skill with an Invalid code
 Given User login MarsPortal
 When User enter into Invalid skill into User Profile '<Skill>' and '<Level>'
 Then User should see an Error Message '<Skill>' and '<Level>'

 Examples: 
 | Skill  | Level            |
 | java12 | Beginner         |
 |        | Beginner         |
 | C#     | ChooseSkillLevel |