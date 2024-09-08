using AdvanceTaskPart1.Pages;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Tests
{
    [TestFixture]
    public class LanguageTest : CommonDriver
    {
        HomePageSteps homePageStepsObj;
        ProfileMenuTab profileMenuTabObj;
        LanguageSteps languageStepsObj;
        public LanguageTest()
        {
            homePageStepsObj = new HomePageSteps();
            profileMenuTabObj = new ProfileMenuTab();
            languageStepsObj = new LanguageSteps();
        }
        [Test, Order(1), Description("This test adds a new entry in language feature")]
        public void TestAddLanguage()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickLangaugesTab();
            languageStepsObj.AddLanguageSteps();
        }
        [Test, Order(2), Description("This test updates the language")]
        public void TestEditLanguage()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickLangaugesTab();
            languageStepsObj.EditLanguageSteps();
        }
        [Test, Order(3), Description("This test deletes the language feature")]
        public void TestDeleteLanguage()
        {
            homePageStepsObj.clickOnProfileTab();
            profileMenuTabObj.clickLangaugesTab();
            languageStepsObj.DeleteLanguageSteps();
        }
    }
}
