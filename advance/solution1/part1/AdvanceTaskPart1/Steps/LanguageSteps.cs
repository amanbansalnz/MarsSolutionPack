using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Utils;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.AssertHelpers;

namespace AdvanceTaskPart1.Steps
{
    public class LanguageSteps
    {
        ProfileMenuTab profileMenuTabObj;
        ProfileTabLanguage profileTabLanguageObj;
        public LanguageSteps()
        {
            profileMenuTabObj = new ProfileMenuTab();
            profileTabLanguageObj = new ProfileTabLanguage();
        }
        public void AddLanguageSteps()
        {
            string addLangFile = "AddLangData.json";
            List<LanguageModel> AddLangData = JsonUtil.ReadJsonData<LanguageModel>(addLangFile);
            foreach (var item in AddLangData)
            {
                string language = item.AddLanguage;
                string langLevel = item.ChooseLanguageLevel;
                profileTabLanguageObj.AddLanguage(language, langLevel);
                LanguageAssertHelper.AddLanguageAssert(language);
            }
        }
        public void EditLanguageSteps()
        {
            AddLanguageSteps();
            string editLangFile = "EditLangData.json";
            List<LanguageModel> EditLangData = JsonUtil.ReadJsonData<LanguageModel>(editLangFile);
            foreach (var item in EditLangData)
            {
                string elanguage = item.AddLanguage;
                string elangLevel = item.ChooseLanguageLevel;
                profileTabLanguageObj.EditLanguage(elanguage, elangLevel);
                LanguageAssertHelper.EditLanguageAssert(elanguage);
            }
        }
        public void DeleteLanguageSteps()
        {
            string deleteLangFile = "DeleteLangData.json";
            List<LanguageModel> DeleteLangData = JsonUtil.ReadJsonData<LanguageModel>(deleteLangFile);
            foreach (var item in DeleteLangData)
            {
                string dlanguage = item.AddLanguage;
                string dlangLevel = item.ChooseLanguageLevel;
                profileTabLanguageObj.AddLanguage(dlanguage, dlangLevel);
                profileTabLanguageObj.DeleteLanguage(dlanguage, dlangLevel);
                LanguageAssertHelper.DeleteLanguageAssert(dlanguage);
            }
        }
    }
}
