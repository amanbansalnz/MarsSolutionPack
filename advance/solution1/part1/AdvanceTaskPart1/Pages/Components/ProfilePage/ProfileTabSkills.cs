using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileTabSkills : CommonDriver
    {
        private static IWebElement addNewSkillButton;
        private static IWebElement skillsTextbox;
        private static IWebElement skillLevelOption;
        private static IWebElement addSkillButton;
        private static IWebElement editSkillTextbox;
        private static IWebElement editSkillLevel;
        private static IWebElement newSkillAdded;
        private static IWebElement editNewSkillButton;
        private static IWebElement updateSkillButton;
        private static IWebElement editSkillAdded;
        private static IWebElement deleteSkillButton;
        private static IWebElement deleteSkillAdded;

        public void renderSkillButton()
        {
            Thread.Sleep(2000);
            addNewSkillButton = driver.FindElement(By.CssSelector("div[class='ui teal button']"));
        }
        public void renderAddSkillComponents()
        {
            try
            {
                skillsTextbox = driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Skill']"));
                skillLevelOption = driver.FindElement(By.Name("level"));
                addSkillButton = driver.FindElement(By.CssSelector("input[class='ui teal button ']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddSkills(string skills, string skillLevel)
        {
            renderSkillButton();
            addNewSkillButton.Click();
            Thread.Sleep(2000);
            renderAddSkillComponents();
            skillsTextbox.SendKeys(skills);
            skillLevelOption.Click();
            skillLevelOption.SendKeys(skillLevel);
            addSkillButton.Click();
            Thread.Sleep(2000);
        }
        public void renderEditIconComponent()
        {
            try
            {
                editNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEditSkillComponents()
        {
            try
            {
                editSkillTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
                editSkillLevel = driver.FindElement(By.Name("level"));
                updateSkillButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void EditSkill(string skills, string skillLevel)
        {
            Thread.Sleep(1000);
            renderEditIconComponent();
            editNewSkillButton.Click();
            Thread.Sleep(2000);
            renderEditSkillComponents();
            editSkillTextbox.Clear();
            editSkillTextbox.SendKeys(skills);
            editSkillLevel.Click();
            editSkillLevel.SendKeys(skillLevel);
            updateSkillButton.Click();
        }
        public void renderDeleteIconComponent()
        {
            try
            {
                deleteSkillButton = driver.FindElement(By.XPath("//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteSkill(string skills, string skillLevel)
        {
            renderDeleteIconComponent();
            deleteSkillButton.Click();
        }
    }
}