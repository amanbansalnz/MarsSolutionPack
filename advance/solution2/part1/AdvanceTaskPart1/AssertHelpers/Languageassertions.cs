using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.Pages;
using Advanced_Task_1.Steps;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.AssertHelpers
{

    public class Languageassertions : BaseSetup
    {
        AddUpdateDeleteLanguageComponent addUpdateDeleteLanguageComponentObj;   
        public Languageassertions() 
        {
            addUpdateDeleteLanguageComponentObj = new AddUpdateDeleteLanguageComponent();
        }
        public void AssertLanguage(LanguageModel languagedata)
        {
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddLanguage.json");                               
                string expectedMessage1 = languagedata.language + " has been added to your languages";
                string expectedMessage2 = "Please enter language and level";
                string expectedMessage3 = "This language is already exist in your language list.";
                string expectedMessage4 = "Duplicated data";
                Assert.That(actualmessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
        }    
         public void AssertupdateLanguage(LanguageModel languageupdatedata)
        {
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateLanguage.json");
            string expectedMessage1 = languageupdatedata.language + " has been updated to your languages";
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already added to your language list.";

            Assert.That(actualmessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));
    }
        public string DeleteAssertion()
        {              
          
            string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
            return actualmessage;
        }
    }
}


