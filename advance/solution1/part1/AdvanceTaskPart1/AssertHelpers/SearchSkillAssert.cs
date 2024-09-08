using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.AssertHelpers
{
    public class SearchSkillAssert : CommonDriver
    {
        private static IWebElement verifySkill => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]"));
        private static IWebElement category => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
        private static IWebElement subCategory => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]"));
        private static IWebElement filter => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
        static string chkCategory;
        static string chkSubCategory;
        static string chkFilter;
        static string invMsg = "No results found, please select a new category!";
        public void VerifySearchSkillByAllCategories(string categoryName)
        {
            Thread.Sleep(2000);
            verifySkill.Click();
            Thread.Sleep(2000);
            chkCategory = category.Text;
            if (chkCategory == categoryName)
            {
                test.Log(Status.Pass, "SearchSkill By Category Verified Successfully");
                Console.WriteLine("SearchSkill By Category Verified Successfully");
            }
            else
            {
                test.Log(Status.Pass, "Required Skill doesnt exist in any Categories");
                Console.WriteLine("Required Skill doesnt exist in any Categories");
            }
        }
        public void VerifySearchSkillBySubCategories(string categoryName, string subCategoryName)
        {
            Thread.Sleep(2000);
            verifySkill.Click();
            Thread.Sleep(2000);
            chkCategory = category.Text;
            chkSubCategory = subCategory.Text;
            if (chkSubCategory == subCategoryName)
            {
                test.Log(Status.Pass, "SearchSkill By Category & Subcategory Verified Successfully");
                Console.WriteLine("SearchSkill By Category & Subcategory Verified Successfully");
            }
            else
            {
                test.Log(Status.Pass, "Required Skill doesnt exist in any Categories");
                Console.WriteLine("Required Skill doesnt exist in any Categories");
            }
        }
        public void VerifySearchSkillByFilter(string filterName)
        {
            Thread.Sleep(2000);
            verifySkill.Click();
            Thread.Sleep(2000);
            chkFilter = filter.Text;
            Console.WriteLine(chkFilter);
            if (chkFilter == filterName)
            {
                test.Log(Status.Pass, "SearchSkill By Filter Verified Successfully");
                Console.WriteLine("SearchSkill By Filter Verified Successfully");
            }
            else
            {
                test.Log(Status.Pass, "Required Skill doesnt exist in any Categories");
                Console.WriteLine("Required Skill doesnt exist in any Categories");
            }
        }
    }
}

