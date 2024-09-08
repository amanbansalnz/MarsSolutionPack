using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;

namespace AdvanceTask_Sprint2.Steps
{
    public class SearchSkillSteps  : BaseSetup
    {
        SearchSkillsComponent SearchSkillsComponentObj;
        ProfileTabPageSteps ProfileTabPageStepsObj;
    public SearchSkillSteps()
    {
        ProfileTabPageStepsObj = new ProfileTabPageSteps();
        SearchSkillsComponentObj = new SearchSkillsComponent();
    }

    public void SearchBySkill(string SearchSkillJsonPath)
    {
        List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>(SearchSkillJsonPath);
        foreach (SearchSkillModel searchskill in SearchSkillModelList)
        {
            SearchSkillsComponentObj.SkillToBeSearched(searchskill);
        }
    }
    public void SearchByUserName(String SearchbyUserNameJsonPath)
    {
        List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>(SearchbyUserNameJsonPath);
        foreach (SearchSkillModel searchuserskill in SearchSkillModelList)
        {
            ProfileTabPageStepsObj.clickSearchSkillIcon();
            Thread.Sleep(4000);
            SearchSkillsComponentObj.SearchUser(searchuserskill);
        }
    }
    public void SearchByCategoryclicked(string SearchbyCategoryJsonPath)
    {
        List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>(SearchbyCategoryJsonPath);
        foreach (SearchSkillModel categoryData in SearchSkillModelList)
        {
            ProfileTabPageStepsObj.clickSearchSkillIcon();
            Thread.Sleep(4000);
           SearchSkillsComponentObj.SearchByCategory(categoryData);
            
        }
    }
    public void SearchByFilterclicked(string SearchByFilterJsonPath)
    {
        List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>(SearchByFilterJsonPath);
        foreach (SearchSkillModel filterData in SearchSkillModelList)
        {
            ProfileTabPageStepsObj.clickSearchSkillIcon();
            Thread.Sleep(4000);
            SearchSkillsComponentObj.SearchByFilter(filterData);
         
        }
    }

}
}