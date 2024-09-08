using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class SkillPage : CommonDriver
    {
        
        private static IWebElement SkillTab => driver.FindElement(By.XPath("//a[contains(text(),'Skills')]"));
       
        private static IWebElement AddNew => driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        private static IWebElement AddSkillTextBox => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseSkillLevel => driver.FindElement(By.Name("level"));
        private static IWebElement Newskill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement Newlevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));

        private static IWebElement AddButton => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));

        
        private static IWebElement EditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        
        private static IWebElement UpdateSkill => driver.FindElement(By.Name("name"));
        private static IWebElement UpdateLevel => driver.FindElement(By.Name("level"));
        private static IWebElement CreatedSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement Createdlevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        

        public void clearExistingdata()
        {
            try
            {
                

                IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
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
        public void AddSkill(string Skill, string Level)
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
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(3000);

            string popupMessage = messageBox.Text;
            Console.WriteLine(popupMessage);
            string expectedMessage2 = "Duplicated data";
            string expectedMessage3 = "Please enter skill and level";
            string expectedMessage4 = "This skill is already exist in your language list.";

            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Skill has been added successfully");
            }
            else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
            {
                IWebElement cancelIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
                cancelIcon.Click();
            }
            else
            {
                Console.WriteLine("Check Error");
            }
            

        }
        public string AddSkill()
        {
            return Newskill.Text;
        }

        public string AddLevel()
        {
            return Newlevel.Text;

        }

        //Edit an already existing skill in the skill list 
        public void EditSkill(string Skill, string Level)
        {
            //Click on EditButton
            Thread.Sleep(3000);
            EditButton.Click();

            //Edit the language
            UpdateSkill.Clear();
            UpdateSkill.SendKeys(Skill);

            //Choose the level from the drop down
            UpdateLevel.Click();
            UpdateLevel.SendKeys(Level);

            //Click on Update button
            UpdateButton.Click();
            Thread.Sleep(2000);

            IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(3000);

            string actualMessage = Messagebox.Text;
            Console.WriteLine(actualMessage);
            string expectedMessage2 = "Please enter skill and level";
            string expectedMessage3 = "This skill is already exist in your skill list.";

            if (actualMessage.Contains("has been updated"))
            {
                Console.WriteLine("Skill has been updated successfully");
            }
            else if ((actualMessage == expectedMessage2 || actualMessage == expectedMessage3))
            {
                IWebElement editCancelBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[2]"));

                editCancelBtn.Click();
                Console.WriteLine("Successfully got the error message");
            }
            else
            {
                Console.WriteLine("Check Error");
            }


        }
        public string getEditedSkill()
        {
            return CreatedSkill.Text;
        }

        public string getEditedLevel()
        {
            return Createdlevel.Text;
        }
        public void DeleteSkill()
        {
            Thread.Sleep(3000);
            DeleteButton.Click();




        }
    }
}

