using Advanced_Task_1.AssertHelpers;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using Advanced_Task_1.Pages;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Steps
{
    public class LanguageStep : BaseSetup
    {
        LanguageComponent languageComponentObj;
        AddUpdateDeleteLanguageComponent addUpdateDeleteLanguageComponentObj;
        Languageassertions LanguageassertionsObj;
        public LanguageStep()
        {
            languageComponentObj = new LanguageComponent();
            addUpdateDeleteLanguageComponentObj = new AddUpdateDeleteLanguageComponent();
            LanguageassertionsObj = new Languageassertions();
        }
        public void AddLanguage()
        {
            List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\AddLanguage.json");
            foreach (LanguageModel languagedata in LanguageModelList)
            {
                languageComponentObj.clickAddLanguage();
                addUpdateDeleteLanguageComponentObj.addNewLanguage(languagedata);
                string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
                LanguageassertionsObj.AssertLanguage(languagedata);
            }
        }
        public void updateLanguage()
        {
            List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UpdateLanguage.json");
            foreach (LanguageModel languageupdatedata in LanguageModelList)
            {
                languageComponentObj.clickUpdateLanguage();
                addUpdateDeleteLanguageComponentObj.updateLanguage(languageupdatedata);
                string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
                LanguageassertionsObj.AssertupdateLanguage(languageupdatedata);
            }
        }
        public void deleteLanguage()
        {
               addUpdateDeleteLanguageComponentObj.DeleteLanguage();
                string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
                LanguageassertionsObj.DeleteAssertion();
            }
    }
}

       