using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class SkillsPage : CommonDriver
    {
        IWebElement addNewSkillButton => driver.FindElement(By.CssSelector("div[class='ui teal button']"));
        IWebElement skillsTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Skill']"));
        IWebElement skillLevelOption => driver.FindElement(By.Name("level"));
        IWebElement addSkillButton => driver.FindElement(By.CssSelector("input[class='ui teal button ']"));
        IWebElement editSkillTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        IWebElement editSkillLevel => driver.FindElement(By.Name("level"));
        IWebElement newSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasking']"));
        IWebElement editNewSkillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        IWebElement updateSkillButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        IWebElement editSkillAdded => driver.FindElement(By.XPath("//td[text()='Multitasker']"));
        IWebElement deleteSkillButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        IWebElement deleteSkillAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        public void ClearData()
        {
            try
            {
                var deleteButton = driver.FindElements(By.CssSelector("i[class='remove icon']"));
                foreach (var button in deleteButton)
                {
                    button.Click();
                }
            }
            catch { }

        }
        public void AddSkills(string skills, string skillLevel)
        {
            //Add new language
            addNewSkillButton.Click();
            //Enter language 
            skillsTextbox.SendKeys(skills);
            //choose language level from dropdown
            skillLevelOption.Click();
            skillLevelOption.SendKeys(skillLevel);
            //click on add button
            addSkillButton.Click();
        }
        public void EditSkill(string skills, string skillLevel)
        {
            Thread.Sleep(1000);
            editNewSkillButton.Click();
            //Enter skill 
            editSkillTextbox.Clear();
            editSkillTextbox.SendKeys(skills);
            //Enter skill level 
            editSkillLevel.Click();
            editSkillLevel.SendKeys(skillLevel);
            //click on update button
            updateSkillButton.Click();
        }
        public void RemoveSkill()
        {
            deleteSkillButton.Click();
        }
    }
}
