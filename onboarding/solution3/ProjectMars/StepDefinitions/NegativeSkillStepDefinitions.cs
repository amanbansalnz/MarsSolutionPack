using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Pages;
using ProjectMars.Utilities;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class NegativeSkillStepDefinitions : CommonDriver
    {

        SignInPage SignInPageObj;

        NegativeSkillPage NegativeSkillPageObj;
        public NegativeSkillStepDefinitions()
        {
            SignInPageObj = new SignInPage();
            NegativeSkillPageObj = new NegativeSkillPage();

        }
        [Given(@"User login MarsPortal")]
        public void GivenUserLoginMarsPortal()
        {
            SignInPageObj.SignInSteps();
            NegativeSkillPageObj.SkillTabClick();
        }

        [When(@"User enter into Invalid skill into User Profile '([^']*)' and '([^']*)'")]
        public void WhenUserEnterIntoInvalidSkillIntoUserProfileAnd(string Skill, string Level)
        {

            NegativeSkillPageObj.clearExistingdata();

            NegativeSkillPageObj.NegativeAddSkill(Skill, Level);
        }

        [Then(@"User should see an Error Message '([^']*)' and '([^']*)'")]
        public void ThenUserShouldSeeAnErrorMessageAnd(string Skill, string Level)
        {

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(3000);

            string popupMessage = messageBox.Text;
            Console.WriteLine(popupMessage);


            string expectedMessage2 = Skill + " has been added to your skills";
            string expectedMessage3 = "Please enter skill and experience level";
            string expectedMessage4 = "This skill is already exist in your skill list.";
            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Skill has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[2]"));
                //IWebElement cancelIcon = driver.FindElement(By.XPath("//tbody/tr[1]/td[1]/div[1]/span[1]/input[2]"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.That(popupMessage, Is.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));

        }
    }
}
