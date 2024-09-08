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
    public class SearchSkillTest : CommonDriver
    {
        SearchSkillSteps searchSkillStepsObj;
        public SearchSkillTest()
        {
            searchSkillStepsObj = new SearchSkillSteps();
        }
        [Test, Order(1), Description("This test verifies the skill by all categories in Search Skill")]
        public void TestSearchSkillByAllCategories()
        {
            searchSkillStepsObj.SearchSkillByAllCategoriesSteps();
        }
        [Test, Order(2), Description("This test verifies the skill by all subcategories in Search Skill")]
        public void TestSearchSkillBySubCategories()
        {
            searchSkillStepsObj.SearchSkillBySubCategoriesSteps();
        }
        [Test, Order(3), Description("This test verifies the skill by all filters in Search Skill")]
        public void TestSearchSkillByFilters()
        {
            searchSkillStepsObj.SearchSkillByFilterSteps();
        }
    }
}
