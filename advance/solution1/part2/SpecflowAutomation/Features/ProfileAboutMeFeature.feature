Feature: ProfileAboutMeFeature

As I Enter the User  details in the Profile about me

User UserInformationDetails

Scenario:01 - successfully entered the profile page
    Given User should be successfully logged with valid credentials
	When  Enter the User Firstname and Lastname details from the json file located at "D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation\\JsonData\\ProfileUsernameData.json"
	Then  User should be successfully enter the name

Scenario Outline:02 - successfully entered the profile page
   Given   User should be successfully logged with valid credentials
   When    Enter the user availability using Json file with located at "D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation\\JsonData\\ProfileAvailabilitydata.json"
   Then    User should be successfully Enter the Availability Type

Scenario Outline:03 - successfully entered the profile page
    Given  User should be successfully logged with valid credentials
	When   Enter the user availability hours using Json file with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ProfileHoursdata.json"
	Then   User should be successfully enter the availability hours

Scenario Outline: 04 - successfully entered the profile page
     Given User should be successfully logged with valid credentials
	 When  Enter the user availability earnTarget using Jsonfile with located at "D:\IC Course\AdvanceSpecflow\Mars-AdvanceSpecflow\SpecflowAutomation\JsonData\ProfileEarnTargetdata.json"
	 Then  User should be successfully enter the  availability earnTarget