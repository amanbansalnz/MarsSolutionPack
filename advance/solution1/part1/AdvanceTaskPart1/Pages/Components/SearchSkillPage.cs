using AdvanceTaskPart1.TestModel;
using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components
{
    public class SearchSkillPage : CommonDriver
    {
        private static IWebElement searchLinkIcon;
        private static IWebElement searchSkillTextBox;

        private static IWebElement filterOnlineBtn;
        private static IWebElement filterOnsiteBtn;
        private static IWebElement filterShowAllBtn;

        public void SearchSkillByAllCategories(SearchSkillCategoryModel skillcategory)
        {
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(1000);
            renderSearchSkillTextBox();
            searchSkillTextBox.SendKeys(skillcategory.Category);
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(2000);
        }
        public void SearchSkillBySubCategories(SearchSkillSubCatModel skillcategory)
        {
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(1000);
            renderSearchSkillTextBox();
            searchSkillTextBox.SendKeys(skillcategory.Category);
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(2000);
            renderSearchSkillTextBox();
            searchSkillTextBox.SendKeys(skillcategory.SubCategory);
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(2000);
        }
        public void SearchSkillByFilter(SearchSkillFilterModel skill)
        {
            renderSearchSkillBtn();
            searchLinkIcon.Click();
            Thread.Sleep(1000);
            renderSearchSkillTextBox();
            searchSkillTextBox.SendKeys(skill.SkillCategory);
            renderFilter();
            switch (skill.filterOption)
            {
                case "Online":
                    filterOnlineBtn.Click();
                    break;
                case "On-Site":
                    filterOnsiteBtn.Click();
                    break;
                case "ShowAll":
                    filterShowAllBtn.Click();
                    break;
                default:
                    Console.WriteLine("Invalid filter option specified.");
                    break;
            }
        }

        public void renderSearchSkillBtn()
        {
            searchLinkIcon = driver.FindElement(By.XPath("//i[@class='search link icon']"));
        }

        public void renderSearchSkillTextBox()
        {
            searchSkillTextBox = driver.FindElement(By.XPath("//input[@placeholder='Search skills']"));
        }
        public void renderFilter()
        {
            filterOnlineBtn = driver.FindElement(By.XPath("//button[contains(text(),'Online')]"));
            filterOnsiteBtn = driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]"));
            filterShowAllBtn = driver.FindElement(By.XPath("//button[contains(text(),'ShowAll')]"));
        }
    }
}
