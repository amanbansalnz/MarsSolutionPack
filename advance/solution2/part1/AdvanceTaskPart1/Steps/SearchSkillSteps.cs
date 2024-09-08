using Advanced_Task_1.Utilities;
using Advanced_Task_1.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.AssertHelpers;

namespace Advanced_Task_1.Steps
{
    public class SearchSkillSteps : BaseSetup
    {
        SearchSkillsComponent SearchSkillsComponentObj;
        SearchSkillAssertions SearchSkillAssertionsObj;
        ProfileTabPageSteps ProfileTabPageStepsObj;

        public SearchSkillSteps()
        {
            ProfileTabPageStepsObj = new ProfileTabPageSteps();
            SearchSkillsComponentObj = new SearchSkillsComponent();
            SearchSkillAssertionsObj = new SearchSkillAssertions();
        }

        public void SearchBySkill()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\SearchSkill.json");
            foreach (SearchSkillModel searchskill in SearchSkillModelList)
            {
                SearchSkillsComponentObj.SkillToBeSearched(searchskill);
                SearchSkillAssertionsObj.SearchSkillAssert(searchskill);
            }
        }
        public void SearchByUserName()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\SearchUserSkill.json");
            foreach (SearchSkillModel searchuserskill in SearchSkillModelList)
            {
                ProfileTabPageStepsObj.clickSearchSkillIcon();
                SearchSkillsComponentObj.SearchUser(searchuserskill);
                SearchSkillAssertionsObj.SearchUserNameAssert(searchuserskill);
            }
        }
        public void SearchByCategoryclicked()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\CategoryData.json");
            foreach (SearchSkillModel categoryData in SearchSkillModelList)
            {
                ProfileTabPageStepsObj.clickSearchSkillIcon();
                SearchSkillsComponentObj.SearchByCategory(categoryData);
                SearchSkillAssertionsObj.SearchCategoryAssert(categoryData);
            }
        }
        public void SearchByFilterclicked()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\FilterData.json");
            foreach (SearchSkillModel filterData in SearchSkillModelList)
            {
                ProfileTabPageStepsObj.clickSearchSkillIcon();
                SearchSkillsComponentObj.SearchByFilter(filterData);
                SearchSkillAssertionsObj.SearchFilterAssert(filterData);
            }
        }

    }
}
