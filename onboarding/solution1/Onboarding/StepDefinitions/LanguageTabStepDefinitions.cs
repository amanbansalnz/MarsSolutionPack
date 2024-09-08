using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Pages;
using SpecFlowProjectMars.Utilities;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace SpecFlowProjectMars.StepDefinitions
{
    [Binding]
    public class LanguageTabStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj;
        ProfileHomePage profilePageObj;
        LanguagePage languagePageObj;
        private static IWebElement popupmsg => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        string popupMsgInv = "Please enter language and level";
        string popMsgSame = "This language is already added to your language list.";
        string popMsgDup = "Duplicated data";
        string popMsgUndefined = "undefined";
        public LanguageTabStepDefinitions()
        {
            loginPageObj = new LoginPage();
            profilePageObj = new ProfileHomePage();
            languagePageObj = new LanguagePage();
        }
        [Given(@"user logs into Mars Portal")]
        public void GivenUserLogsIntoMarsPortal()
        {
            loginPageObj.LoginActions("geothy@gmail.com", "7geothy*");
            profilePageObj.VerifyLoggedInUser();
        }
        [Given(@"navigates to Languages tab in Profile Page")]
        public void GivenNavigatesToLanguagesTabInProfilePage()
        {
            profilePageObj.NavigateToLanguagePanel();
        }
        [When(@"user enters Language ""([^""]*)"" and Language Level ""([^""]*)""")]
        public void WhenUserEntersLanguageAndLanguageLevel(string language, string level)
        {
            languagePageObj.ClearData();
            languagePageObj.AddLanguage(language, level);
        }
        [Then(@"the language ""([^""]*)"" should be added to Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeAddedToLanguagesTabInProfilePage(string language)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            string popupMsgadd = language + " has been added to your languages";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgUndefined).Or.EqualTo(popMsgDup));
        }
        [When(@"user edits Language ""([^""]*)"" and Language Level ""([^""]*)""")]
        public void WhenUserEditsLanguageAndLanguageLevel(string language, string level)
        {
            languagePageObj.EditLanguage(language, level);
        }

        [Then(@"the language ""([^""]*)"" should be edited into Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeEditedIntoLanguagesTabInProfilePage(string language)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            //Verify the pop up message
            string popupMsgadd = language + " has been updated to your languages";
            Assert.That(popupMsgBox, Is.EqualTo(popupMsgadd).Or.EqualTo(popupMsgInv).Or.EqualTo(popMsgSame).Or.EqualTo(popMsgDup).Or.EqualTo(popMsgUndefined));
        }
        [When(@"user deletes the Language ""([^""]*)""")]
        public void WhenUserDeletesTheLanguage(string language)
        {
            languagePageObj.RemoveLanguage();
        }

        [Then(@"the language ""([^""]*)"" should be deleted from Languages tab in Profile Page")]
        public void ThenTheLanguageShouldBeDeletedFromLanguagesTabInProfilePage(string language)
        {
            Thread.Sleep(3000);
            string popupMsgBox = popupmsg.Text;
            Console.WriteLine(popupMsgBox);
            //Verify the pop up message
            string popupMsgadd = language + " has been deleted from your languages";
            Assert.AreEqual(popupMsgadd, popupmsg.Text);
        }

    }
}
