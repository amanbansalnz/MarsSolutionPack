using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using AdvanceTask_Sprint2.AssertHelpers;




namespace AdvanceTask_Sprint2.Steps
{
    public class LanguageStep : BaseSetup
    {
       
        LanguageComponent languageComponentObj;
        AddUpdateDeleteLanguageComponent addUpdateDeleteLanguageComponentObj;
            public LanguageStep()
            {
                languageComponentObj = new LanguageComponent();
                addUpdateDeleteLanguageComponentObj = new AddUpdateDeleteLanguageComponent();
            }
            public void AddLanguage(string AddJsonFilePath)
            {
                List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>(AddJsonFilePath);
                foreach (LanguageModel languagedata in LanguageModelList)
                {
                    languageComponentObj.clickAddLanguage();
                    addUpdateDeleteLanguageComponentObj.addNewLanguage(languagedata);
                    string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                    Console.WriteLine(actualmessage);
                }
            }
       
        public void updateLanguage(string UpdateJsonFilePath)
            {
            List<LanguageModel> LanguageModelList = JsonHelper.ReadTestDataFromJson<LanguageModel>(UpdateJsonFilePath);
                foreach (LanguageModel languageupdatedata in LanguageModelList)
                {
                    languageComponentObj.clickUpdateLanguage();
                    addUpdateDeleteLanguageComponentObj.updateLanguage(languageupdatedata);
                    string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                    Console.WriteLine(actualmessage);               
                }
            }
            public void deleteLanguage()
            {
                addUpdateDeleteLanguageComponentObj.DeleteLanguage();
                string actualmessage = addUpdateDeleteLanguageComponentObj.GetMessageBoxText();
                Console.WriteLine(actualmessage);
            }
        }
    }


