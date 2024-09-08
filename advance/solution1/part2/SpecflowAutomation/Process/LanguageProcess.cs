using SpecflowAutomation.Pages.Components.ProfileOverview;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Process
{
    public class LanguageProcess:Base
    {
        ProfileMenuTab profileMenuTabObj;
        LanguageComponent languageComponentObj;
        public LanguageProcess()
        {
            profileMenuTabObj = new ProfileMenuTab();
            languageComponentObj = new LanguageComponent();
        }
        public void ClearLanguageProcess()
        {
            profileMenuTabObj.clickLanguagesTab();
            languageComponentObj.clearExistingdata();
        }
        public void languageAddProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguagesTab();
            languageComponentObj.addNewLanguage(data);
        }
        public void languageUpdateProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguagesTab();
            profileMenuTabObj.clickLanguageEditIcon();
            languageComponentObj.editLanguage(data);
        }
        public void languageDeleteProcess(string language)
        {
            profileMenuTabObj.clickLanguagesTab();
            languageComponentObj.deleteLanguageData(language);
        }
        public void languageAddNegativeProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguagesTab();
            languageComponentObj.addNegativeLanguage(data);
        }
        public void languageUpdatedNegativeProcess(LanguageTestModel data)
        {
            profileMenuTabObj.clickLanguagesTab();
            profileMenuTabObj.clickLanguageEditIcon();
            languageComponentObj.negtiveEditLanguage(data);
        }
    }
}
