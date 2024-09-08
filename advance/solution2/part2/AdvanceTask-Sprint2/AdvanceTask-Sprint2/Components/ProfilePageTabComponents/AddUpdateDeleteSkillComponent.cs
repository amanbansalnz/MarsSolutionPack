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
    public class AddUpdateDeleteSkillComponent : BaseSetup
    {
        private IWebElement AddSkillTextBox;
        private IWebElement ChooseSkillLevel;
        private IWebElement AddButton;
        private IWebElement messageBox;
        private string message = "";
        private IWebElement UpdateSkillTextBox;
        private IWebElement UpdateSkillLevel;
        private IWebElement UpdateButton;
        public void renderAddComponents()
        {
            try
            {
                AddSkillTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
                ChooseSkillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
                AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAddMessage()
        {
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddSkills(SkillModel skilldata)
        {
            renderAddComponents();
            //Enter the skills that needs to be added
            AddSkillTextBox.SendKeys(skilldata.skill);
            Thread.Sleep(2000);
            //Choose the skill level
            ChooseSkillLevel.Click();
            ChooseSkillLevel.SendKeys(skilldata.skillLevel);
            //Click onn Add button
            AddButton.Click();
            Thread.Sleep(3000);
        }
        public void renderupdateComponents()
        {
            try
            {
                UpdateSkillTextBox = driver.FindElement(By.Name("name"));
                UpdateSkillLevel = driver.FindElement(By.Name("level"));
                UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void updateSkills(SkillModel skilldata)
        {
            renderupdateComponents();
            UpdateSkillTextBox.SendKeys(Keys.Control + "A");
            UpdateSkillTextBox.SendKeys(Keys.Backspace);
            UpdateSkillTextBox.SendKeys(skilldata.skill);
            //Choose the level from the drop down
            UpdateSkillLevel.Click();
            UpdateSkillLevel.SendKeys(skilldata.skillLevel);
            //Click on update button
            UpdateButton.Click();
            Thread.Sleep(2000);
        }
        public void deleteSkill(SkillModel skilldata)
        {
            try
            {
                var deleteIcon = driver.FindElement(By.XPath($"//tbody[tr[td[text()='{skilldata.skill}'] and td[text()='{skilldata.skillLevel}']]]//i[@class='remove icon']"));
                // Find and click the delete icon in the row
                deleteIcon.Click();
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {

                Console.WriteLine("DeleteLanguage element not found");
            }
        }
        public string GetMessageBoxText()
        {
            renderAddMessage();
            //get the text of the message element
            string Message = messageBox.Text;
            return Message;
        }
    }
}

