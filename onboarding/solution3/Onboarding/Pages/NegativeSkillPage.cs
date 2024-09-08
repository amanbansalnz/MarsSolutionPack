using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
   public class NegativeSkillPage : CommonDriver
    {
        private static IWebElement SkillTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));

        private static IWebElement AddNew => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        private static IWebElement AddSkillTextBox => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseSkillLevel => driver.FindElement(By.Name("level"));
        private static IWebElement NewInvalidskill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement NewInvalidlevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

        private static IWebElement AddButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
        public void clearExistingdata()
        {
            
            
                try
                {
                   
                    var DeleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    
                    foreach (var Button in DeleteButtons)
                    {
                        Button.Click();
                    }

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("no items to delete");
                }
            

        }
        public void SkillTabClick()
        {
            SkillTab.Click();
        }
        //Adding New skill to the skill list
        public void NegativeAddSkill(string Skill, string Level)
        {
            //Click on AddNew button
            AddNew.Click();

            //Enter the skill that needs to be added
            AddSkillTextBox.SendKeys(Skill);

            //Choose the Skill level
            Thread.Sleep(3000);
            ChooseSkillLevel.Click();

            //Newlevel.Click();
            ChooseSkillLevel.SendKeys(Level);

            //Click on Add button
            AddButton.Click();
            Thread.Sleep(3000);
            

           

        }
        public string getAddSkill()
        {
            return NewInvalidskill.Text;
        }

        public string getAddLevel()
        {
            return NewInvalidlevel.Text;

        }
    }
}
