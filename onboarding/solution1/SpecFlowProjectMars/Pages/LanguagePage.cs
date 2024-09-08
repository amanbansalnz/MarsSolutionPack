using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class LanguagePage : CommonDriver
    {
        private static IWebElement addNewLangButton => driver.FindElement(By.XPath("//div[contains(text(),'Add New')]"));
        private static IWebElement languageTextbox => driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
        private static IWebElement selectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement addLangButton => driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
        private static IWebElement popupmsg => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));
        private static IWebElement editNewLangButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement editLangTextbox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private static IWebElement editselectLangLevelOption => driver.FindElement(By.Name("level"));
        private static IWebElement updateLangButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editLangAdded => driver.FindElement(By.XPath("//td[text()='Manglish']"));
        private static IWebElement deleteLangButton => driver.FindElement(By.CssSelector("i[class='remove icon']"));
        private static IWebElement deleteLangAdded => driver.FindElement(By.CssSelector("div[class='ns-box-inner']"));

        public void ClearData()
        {
            try
            {
                var deleteButton = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach (var button in deleteButton)
                {
                    button.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void AddLanguage(string language, string level)
        {
            //Add new language
            addNewLangButton.Click();
            //Enter language 
            languageTextbox.SendKeys(language);
            //choose language level from dropdown
            selectLangLevelOption.Click();
            selectLangLevelOption.SendKeys(level);
            //click on add button
            addLangButton.Click();
            Thread.Sleep(3000);
        }
        public void EditLanguage(string language, string level)
        {
            editNewLangButton.Click();
            Thread.Sleep(1000);
            //Enter language 
            editLangTextbox.Clear();
            editLangTextbox.SendKeys(language);
            //choose language level from dropdown
            editselectLangLevelOption.Click();
            editselectLangLevelOption.SendKeys(level);
            Thread.Sleep(1000);
            //click on add button
            updateLangButton.Click();
        }
        public void RemoveLanguage()
        {
            deleteLangButton.Click();
        }
    }
}
