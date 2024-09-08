using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileTabLanguage : CommonDriver
    {
        private static IWebElement addNewLangButton;
        private static IWebElement languageTextbox;
        private static IWebElement selectLangLevelOption;
        private static IWebElement addLangButton;
        private static IWebElement editNewLangButton;
        private static IWebElement editLangTextbox;
        private static IWebElement editselectLangLevelOption;
        private static IWebElement updateLangButton;
        private static IWebElement deleteLangButton;
        public void renderLangButtons()
        {
            Thread.Sleep(2000);
            addNewLangButton = driver.FindElement(By.XPath("//div[contains(@class,'ui teal')][1]"));
        }
        public void renderAddLangComponents()
        {
            try
            {
                languageTextbox = driver.FindElement(By.XPath("//input[@type='text'][@placeholder='Add Language']"));
                selectLangLevelOption = driver.FindElement(By.Name("level"));
                addLangButton = driver.FindElement(By.XPath("//input[@value=\"Add\"]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddLanguage(string language, string level)
        {
            renderLangButtons();
            addNewLangButton.Click();
            Thread.Sleep(2000);
            renderAddLangComponents();
            languageTextbox.SendKeys(language);
            selectLangLevelOption.Click();
            selectLangLevelOption.SendKeys(level);
            addLangButton.Click();
            Thread.Sleep(3000);
        }

        public void renderEditIconComponent()
        {
            try
            {
                editNewLangButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEditLangComponents()
        {
            try
            {
                editLangTextbox = driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
                editselectLangLevelOption = driver.FindElement(By.Name("level"));
                updateLangButton = driver.FindElement(By.XPath("//input[@value='Update']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public string EditLanguage(string language, string level)
        {
            Thread.Sleep(1000);
            renderEditIconComponent();
            editNewLangButton.Click();
            Thread.Sleep(2000);
            renderEditLangComponents();
            editLangTextbox.Clear();
            editLangTextbox.SendKeys(language);
            editselectLangLevelOption.Click();
            editselectLangLevelOption.SendKeys(level);
            updateLangButton.Click();
            return language;
        }
        public void renderDeleteIconComponent()
        {
            try
            {
                deleteLangButton = driver.FindElement(By.XPath("//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void DeleteLanguage(string language, string level)
        {
            renderDeleteIconComponent();
            deleteLangButton.Click();
        }
    }
}
