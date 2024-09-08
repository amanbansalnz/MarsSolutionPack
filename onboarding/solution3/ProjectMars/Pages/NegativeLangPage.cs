using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMars.Pages
{
    public class NegativeLangPage : CommonDriver
    {
        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
       
        private static IWebElement AddLanguageTextBox => driver.FindElement(By.Name("name"));
        private static IWebElement ChooseLanguageLevel => driver.FindElement(By.Name("level"));
        private static IWebElement NewInvalidLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));

         private static IWebElement NewInvalidLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));

        public void ClearExistingdata()
        {
            IWebElement languageTable = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            IList<IWebElement>languageTableRows = languageTable.FindElements(By.TagName("tr"));
            int rowCount = languageTableRows.Count();
            for (int i = rowCount - 1; i >= 1; i--)
            {
                try
                {
                    IWebElement row = languageTableRows[i];

                    IWebElement deleteicon = row.FindElement(By.XPath("//i[@class='remove icon']"));
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                    Console.WriteLine($"Deleting row{i}");
                    deleteicon.Click();
                    Thread.Sleep(1000);

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
        }
        //Adding New language to the language list
        public void InvalidLanguage(string Language, string Level)
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

            Thread.Sleep(2000);
            
          
          
        }

        public string getInvalidLanguage()
        {


            return NewInvalidLanguage.Text;
        }

        public string getInvalidLevel()
        {
            return NewInvalidLevel.Text;

        }
    }
     
}
