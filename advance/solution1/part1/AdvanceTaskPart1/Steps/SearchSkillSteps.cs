using AdvanceTaskPart1.AssertHelpers;
using AdvanceTaskPart1.Pages.Components;
using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Steps
{
    public class SearchSkillSteps
    {
        SearchSkillPage searchSkillPageObj;
        SearchSkillAssert searchSkillAssertObj;

        public SearchSkillSteps()
        {
            searchSkillPageObj = new SearchSkillPage();
            searchSkillAssertObj = new SearchSkillAssert();
        }
        public void SearchSkillByAllCategoriesSteps()
        {
            string SearchSkillFile = "SearchSkillCategory.json";
            List<SearchSkillCategoryModel> SearchSkillData = JsonUtil.ReadJsonData<SearchSkillCategoryModel>(SearchSkillFile);
            foreach (SearchSkillCategoryModel skillData in SearchSkillData)
            {
                searchSkillPageObj.SearchSkillByAllCategories(skillData);
                searchSkillAssertObj.VerifySearchSkillByAllCategories(skillData.Category);
            }
        }
        public void SearchSkillBySubCategoriesSteps()
        {
            string searchSkillSub = "SearchSkillCatSub.json";
            List<SearchSkillSubCatModel> SearchData = JsonUtil.ReadJsonData<SearchSkillSubCatModel>(searchSkillSub);
            foreach (SearchSkillSubCatModel skillData in SearchData)
            {
                searchSkillPageObj.SearchSkillBySubCategories(skillData);
                searchSkillAssertObj.VerifySearchSkillBySubCategories(skillData.Category, skillData.SubCategory);
            }
        }
        public void SearchSkillByFilterSteps()
        {
            string searchSkillFilter = "SearchSkillFilter.json";
            List<SearchSkillFilterModel> SearchData = JsonUtil.ReadJsonData<SearchSkillFilterModel>(searchSkillFilter);
            foreach (SearchSkillFilterModel skillData in SearchData)
            {
                searchSkillPageObj.SearchSkillByFilter(skillData);
                searchSkillAssertObj.VerifySearchSkillByFilter(skillData.filterOption);
            }
        }
    }
}
