using Advanced_Task_1.Pages;
using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Components.ProfilePageTabComponents
{
    public class AddUpdateDeleteLanguageComponent : BaseSetup
    {

        private IWebElement AddLanguageTextBox;
        private IWebElement ChooseLanguageLevel;
        private IWebElement AddButton;
        private IWebElement UpdateLangauge;
        private IWebElement UpdateLevel;
        private IWebElement UpdateButton;
        private IWebElement messageBox;
        private string Message = "";

        public void renderAddComponents()
        {
            try
            {
                AddLanguageTextBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
                ChooseLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
                AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
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
        public void renderUpdateLanguage()
        {
            try
            {
                UpdateLangauge = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
                UpdateLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));
                UpdateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void addNewLanguage(LanguageModel languagedata)
        {         
            renderAddComponents();
            AddLanguageTextBox.SendKeys(languagedata.language);
            //Choose the language level
            ChooseLanguageLevel.Click();
            ChooseLanguageLevel.SendKeys(languagedata.level);
            //Click on Add button
            AddButton.Click();
            Thread.Sleep(5000);
        }
        public void updateLanguage(LanguageModel languageupdatedata)
        {
              renderUpdateLanguage();
                //Edit the language
                UpdateLangauge.Clear();
                UpdateLangauge.SendKeys(languageupdatedata.language);
                Thread.Sleep(1000);
                //Choose the level from the drop down
                UpdateLevel.Click();
                Thread.Sleep(1000);
                UpdateLevel.SendKeys(languageupdatedata.level);
                //Click on Update button
                UpdateButton.Click();
                Thread.Sleep(2000);
        }
        public void DeleteLanguage()
        {
            IWebElement languageTable = driver.FindElement(By.XPath("//table[@class='ui fixed table']"));
            IList<IWebElement> languageTableRows = languageTable.FindElements(By.TagName("tr"));

            int rowCount = languageTableRows.Count;

            for (int i = rowCount - 1; i >= 1; i--)
            {
                try
                {
                    IWebElement row = languageTableRows[i];
                    IWebElement deleteicon = row.FindElement(By.XPath("//i[@class='remove icon']"));
                    // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    // wait.Until(ExpectedConditions.ElementToBeClickable(deleteicon));
                    Console.WriteLine($"Deleting row {i}");
                    deleteicon.Click();
                    Thread.Sleep(5000);
                }
                catch (StaleElementReferenceException) { }
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




