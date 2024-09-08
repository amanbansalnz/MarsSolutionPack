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
    public class NegativeLanguageFeatureStepDefinitions : CommonDriver
    {
        SignInPage SignInPageObj;
        NegativeLangPage NegativePageObj;
        public NegativeLanguageFeatureStepDefinitions()
        {
            SignInPageObj = new SignInPage();
            NegativePageObj = new NegativeLangPage();

        }
        [Given(@"User enter in to Marsportal")]
        public void GivenUserEnterInToMarsportal()
        {
            SignInPageObj.SignInSteps();
        }

        [When(@"User enter an invalid language code and level '([^']*)'and '([^']*)'")]
        public void WhenUserEnterAnInvalidLanguageCodeAndLevelAnd(string Language, string Level)
        {
            NegativePageObj.ClearExistingdata();
            NegativePageObj.InvalidLanguage(Language, Level);
        }

        [Then(@"User should see an error message '([^']*)' and '([^']*)'")]
        public void ThenUserShouldSeeAnErrorMessageAnd(string Language, string Level)
        {

            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(3000);

            string popupMessage = messageBox.Text;
            Console.WriteLine(popupMessage);


            string expectedMessage2 = Language + " has been added to your languages";
            string expectedMessage3 = "Please enter language and level";
            string expectedMessage4 = "This language is already exist in your language list.";
            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Language has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
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
