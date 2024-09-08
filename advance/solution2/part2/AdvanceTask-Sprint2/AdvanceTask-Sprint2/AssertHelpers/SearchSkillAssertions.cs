using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.AssertHelpers
{
    public class SearchSkillAssertions : BaseSetup
    {
        public void SearchSkillAssert(SearchSkillModel searchskill)
        {
            IWebElement ActualSkill = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));
            string actualskill = ActualSkill.Text;
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\SearchSkill.json");
            string expectedSkill = searchskill.skill;
            Assert.AreEqual(actualskill, expectedSkill, "The skill you are searching has been found");
            Console.WriteLine("SearchSkillAssert passed: The skill you are searching has been found");
        }
        public void SearchUserNameAssert(SearchSkillModel searchuserskill)
        {
            IWebElement ActualUserName = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]"));
            string actualUserName = ActualUserName.Text;
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\SearchByUserName.json");
            string expectedUser = searchuserskill.username;
            if (actualUserName.Contains(expectedUser, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("SearchUserNameAssert passed: The User skill you are searching has been found");
            }
            else
            {
                Assert.Fail("The User skill you are searching has not been found");
            }
        }

        public void SearchCategoryAssert(SearchSkillModel categoryData)
        {
            IWebElement TopSkill = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
            TopSkill.Click();
            Thread.Sleep(5000);
            IWebElement ActualCategory = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
            string actualCategory = ActualCategory.Text;
            string expectedCategory = categoryData.category;
            IWebElement categoryElement = driver.FindElement(By.LinkText(expectedCategory));
            if (actualCategory == expectedCategory)
            {
                Console.WriteLine("SearchCategoryAssert passed: The Category skill you are searching has been found");
            }
            else
            {
                Assert.Fail("The Category skill you are searching has not been found");
            }

        }
        public void SearchFilterAssert(SearchSkillModel filterData)
        {
            IWebElement TopSkill = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
            TopSkill.Click();
            Thread.Sleep(5000);
            IWebElement ActualFilter = driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
            string actualFilter = ActualFilter.Text;
            List<SearchSkillModel> SearchSkillModelList = JsonHelper.ReadTestDataFromJson<SearchSkillModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\FilterData.json");
            string expectedFilter = filterData.filteroption;
            if (actualFilter == expectedFilter)
            {
                Console.WriteLine("SearchFilterAssert passed: The Filter skill you are searching has been found");
            }
            else
            {
                Assert.Fail("The Filter skill you are searching has not been found");
            }

        }
    }

}
