using AdvanceTask_Sprint2.AssertHelpers;
using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
using AdvanceTask_Sprint2.Steps;
using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvanceTask_Sprint2.StepDefinitions
{
    [Binding]
    public class SearchSkill_TestStepDefinitions
    {
        SearchSkillSteps SearchSkillStepsObj;
        ProfileTabPageSteps profileTabPageStepsObj;
        SearchSkillsComponent SearchSkillsComponentObj;
        SearchSkillAssertions SearchSkillAssertionsObj;
        public SearchSkill_TestStepDefinitions()
        {
            SearchSkillStepsObj = new SearchSkillSteps();
            profileTabPageStepsObj = new ProfileTabPageSteps();
            SearchSkillsComponentObj = new SearchSkillsComponent();
            SearchSkillAssertionsObj = new SearchSkillAssertions();
        }

        [When(@"User searches for skills with data ""([^""]*)""")]
        public void WhenUserSearchesForSkillsWithData(string SearchSkillJsonPath)
        {
            SearchSkillStepsObj.SearchBySkill(SearchSkillJsonPath);
            Thread.Sleep(5000);
        }

        [Then(@"User should be able to see a list of skills related to the search")]
        public void ThenUserShouldBeAbleToSeeAListOfSkillsRelatedToTheSearch()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\SearchSkill.json");
            foreach (SearchSkillModel searchskill in SearchSkillModelList)
            {              
              SearchSkillAssertionsObj.SearchSkillAssert(searchskill);
            }
        }

        [When(@"User searches by Usernames with data ""([^""]*)""")]
        public void WhenUserSearchesByUsernamesWithData(string SearchbyUserNameJsonPath)
        {
            SearchSkillStepsObj.SearchByUserName(SearchbyUserNameJsonPath);
            Thread.Sleep(4000);
        }

        [Then(@"User should see a list of users with matching usernames")]
        public void ThenUserShouldSeeAListOfUsersWithMatchingUsernames()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\SearchByUserName.json");
            foreach (SearchSkillModel searchuserskill in SearchSkillModelList)
            {
                SearchSkillAssertionsObj.SearchUserNameAssert(searchuserskill);
            }
        }


        [When(@"User searches by Category with data ""([^""]*)""")]
        public void WhenUserSearchesByCategoryWithData(string SearchbyCategoryJsonPath)
        {
            SearchSkillStepsObj.SearchByCategoryclicked(SearchbyCategoryJsonPath);
            Thread.Sleep(4000);
        }

        [Then(@"User should see a list of skills in that category")]
        public void ThenUserShouldSeeAListOfSkillsInThatCategory()
        {

            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\CategoryData.json");
            foreach (SearchSkillModel categoryData in SearchSkillModelList)
            {

                SearchSkillAssertionsObj.SearchCategoryAssert(categoryData);
            }
        }

        [When(@"User searches using filters with data ""([^""]*)""")]
        public void WhenUserSearchesUsingFiltersWithData(string SearchByFilterJsonPath)
        {
            SearchSkillStepsObj.SearchByFilterclicked(SearchByFilterJsonPath);
            Thread.Sleep(4000);
        }

        [Then(@"User should see a refined list based on the applied filters")]
        public void ThenUserShouldSeeARefinedListBasedOnTheAppliedFilters()
        {
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\FilterData.json");
            foreach (SearchSkillModel filterData in SearchSkillModelList)
            {
                SearchSkillAssertionsObj.SearchFilterAssert(filterData);
            }
        }
    }
}

