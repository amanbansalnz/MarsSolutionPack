Feature: 1.LangFeature

Scenario: A.Add a Language To User Profile
Given User Able Login Into MarsPortal Application Successfully
When Create a NewLanguage Into User Profile '<Language>' and '<Level>'
Then The NewLanguage Record Created '<Language>' and '<Level>' successfully created

Examples: 
| Language | Level                 |
| Tamil    | Basic                 |
| Malayalm  | Basic				   |	
|Telgu | Basic |
| Chinese | Basic |

Scenario: B.Edit a Existing Language in User Profile
Given User Logs Into MarsPortal
When Edit a Existing Language into User Profile '<Language>' and '<Level>'
Then The NewLanguage Record Created '<Language>' and '<Level>' successfully

Examples: 
| Language    | Level          |
| English     | Basic          |
| Telgu       | Basic          |
| Malayalm    | Basic          |

Scenario: C.Delete a Existing Language in User Profile
Given User Logs Into MarsPortal successfully
When  Delete the added language 


Examples: 
| Language | Level |
| English  | Basic |

