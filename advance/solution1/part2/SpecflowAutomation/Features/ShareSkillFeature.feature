Feature: ShareSkillFeature

User add,Update and Delete ShareSkill details.

ShareSkillDetails
Scenario: 01 - Successfully Enter their Shareskill Details.
	Given  User Successfully Logged in with valid details.
	When   User add share skill  using Json File with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ShareSkillAddData.json"
	Then   User Should be successfully added the ShareSkill.

Scenario Outline: 02 - Successfully Enter their Shareskill Details.
	Given  User Successfully Logged in with valid details.
	When   User update the share skill  using Json File with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ShareSkillUpdateData.json"
	Then   User Should be successfully updated the ShareSkill.

Scenario Outline: 03 -  Successfully Enter their Shareskill Details.
	Given  User Successfully Logged in with valid details.
	When   User delete the share skill  using Json File with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ShareSkillDeleteData.json"
	Then   User Should be successfully Deleted the ShareSkill.

Scenario Outline: 04 - Successfully Enter their Shareskill Details.
	Given  User Successfully Logged in with valid details.
	When   User add negative share skill  using Json File with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ShareSkillAddNegativedata.json"
	Then   User Should be successfully got the error message while added negative the ShareSkill.

Scenario Outline: 05 - Successfully Enter their Shareskill Details.
	Given  User Successfully Logged in with valid details.
	When   User update negative share skill  using Json File with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ShareSkillUpdateNegativeData.json"
	Then   User Should be successfully got the error message while Updated negative ShareSkill.

