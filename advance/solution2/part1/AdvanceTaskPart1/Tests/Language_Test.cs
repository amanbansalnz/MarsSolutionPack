using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Tests
{
    [TestFixture]
    public class LanguageTest : BaseSetup
    {
        SignIn signInObj;
        LoginPage loginPageObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        LanguageStep languageStepObj;
        ActualState ActualStateObj;
        public LanguageTest()
        {
            signInObj = new SignIn();
            loginPageObj = new LoginPage();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            languageStepObj = new LanguageStep();
            ActualStateObj = new ActualState();
        }

        [Test, Order(1), Description("Verify that a language and its level can be added.")]
        public void AddLanguageandLevel()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickLangaugesTab();
            ActualStateObj.TableState();
            languageStepObj.AddLanguage();
        }

        [Test, Order(2), Description("Verify that a language and its level can be updated.")]
        public void UpdateLanguageandLevel()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickLangaugesTab();
            ActualStateObj.TableState();
            languageStepObj.AddLanguage();
            languageStepObj.updateLanguage();
        }

        [Test, Order(3), Description("Verify that a language and its level can be deleted.")]
        public void DeleteLanguageLevel()
        {
            signInObj.ClickSignIn();
            loginPageObj.LoginSteps();
            profileTabPageStepsObj.clickLangaugesTab();
            languageStepObj.AddLanguage();
            languageStepObj.deleteLanguage();
        }
    }
}


