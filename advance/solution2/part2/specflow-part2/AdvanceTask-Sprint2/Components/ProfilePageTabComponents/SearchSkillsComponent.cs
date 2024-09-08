using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Components.ProfilePageTabComponents
{
    public class SearchSkillsComponent : BaseSetup
    {
        private IWebElement searchSkills;
        private IWebElement clickSearch;
        private IWebElement AdduserName;
        private IWebElement Clickusername;

        public void renderAddComponents()
        {
            try
            {
                searchSkills = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderClicksearchComponents()
        {
            try
            {

                clickSearch = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAdduser()
        {
            try
            {
                AdduserName = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderclickuser()
        {
            try
            {
                Clickusername = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void SkillToBeSearched(SearchSkillModel searchskill)
        {
            renderAddComponents();
            searchSkills.Click();
            searchSkills.SendKeys(searchskill.skill);
            Thread.Sleep(2000);
            renderClicksearchComponents();
            clickSearch.Click();
        }

        public void SearchUser(SearchSkillModel searchuserskill)
        {
            renderAdduser();
            AdduserName.SendKeys(searchuserskill.username);
            Thread.Sleep(2000);
            renderclickuser();
            Clickusername.Click();
        }
        public void SearchByCategory(SearchSkillModel categoryData)
        {
            string categoryToSelect = categoryData.category;
            IWebElement categoryElement = driver.FindElement(By.LinkText(categoryToSelect));
            categoryElement.Click();
            Thread.Sleep(2000);
            string SubcategoryToSelect = categoryData.subcategory;
            IWebElement SubcategoryElement = driver.FindElement(By.LinkText(SubcategoryToSelect));
            SubcategoryElement.Click();
        }

        public void SearchByFilter(SearchSkillModel filterData)
        {
            string buttonText = filterData.filteroption;
            string xpathExpression = $"//button[text()='{buttonText}']";
            IWebElement buttonElement = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[5]/button[1]"));
            buttonElement.Click();
        }

    }
}
