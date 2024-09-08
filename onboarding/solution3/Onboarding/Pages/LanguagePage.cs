
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement AddLanguageTextBox => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseLanguageLevel => driver.FindElement(By.Name("level"));


        
         private static IWebElement Newlanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        
        private static IWebElement Newlevel => driver.FindElement(By.XPath("//td[contains(text(),'Basic')]"));


        private static IWebElement AddButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        
        private static IWebElement EditButton => driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
        
        private static IWebElement UpdateLanguage => driver.FindElement(By.Name("name"));
        
        private static IWebElement UpdateLevel => driver.FindElement(By.Name("level"));
        private static IWebElement Createdlanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement Createdlevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));

        
       
        private static IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        public void clearExistingdata()
        {
            try
            {
               
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }
        //Adding New language to the language list
        public void AddLanguage(string Language, string Level)
        {
            //Click on AddNew button
            Thread.Sleep(1000);
            AddNew.Click();

            //Enter the language that needs to be added
            AddLanguageTextBox.SendKeys(Language);

            //Choose the language level
            Thread.Sleep(3000);
            ChooseLanguageLevel.Click();
             ChooseLanguageLevel.SendKeys(Level);

            //Click on Add button
            AddButton.Click();
            Thread.Sleep(3000);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Thread.Sleep(3000);

            string popupMessage = messageBox.Text;
            Console.WriteLine(popupMessage);
            string expectedMessage2 = "Duplicated data";
            string expectedMessage3 = "Please enter language and level";
            string expectedMessage4 = "This language is already exist in your language list.";

            if (popupMessage.Contains("has been added"))
            {
                Console.WriteLine("Language has been added successfully");
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
        public string getAddLanguage()
        {
            return Newlanguage.Text;
        }

        public string getAddLevel()
        {
            return Newlevel.Text;

        }


        //Edit an already existing language in the language list 
        public void EditLanguage(string Language, string Level)
        {
            //Click on EditButton
            Thread.Sleep(3000);
            EditButton.Click();

            //Edit the language
            UpdateLanguage.Clear();
            UpdateLanguage.SendKeys(Language);

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
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already exist in your language list.";
            if (actualMessage.Contains("has been updated"))
            {
                Console.WriteLine("Language has been updated successfully");
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
        public string getEditedLanguage()
        {
            return Createdlanguage.Text;
        }

        public string getEditedLevel()
        {
            return Createdlevel.Text;
        }

        //Deleting a language from the language list
        public void DeleteLanguage()
        {
            Thread.Sleep(2000);
            DeleteButton.Click();




        }

    }
}
