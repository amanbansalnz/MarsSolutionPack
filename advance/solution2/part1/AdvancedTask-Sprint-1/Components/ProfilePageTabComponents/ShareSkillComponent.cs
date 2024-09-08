using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Components.ProfilePageTabComponents
{
    public class ShareSkillComponent : BaseSetup
    {
        private IWebElement Title;
        private IWebElement Description;
        private IWebElement Category;
        private IWebElement Subcategory;
        private IWebElement AddTags;
        private IWebElement HourlyBasis;
        private IWebElement ClickOneOff;
        private IWebElement messageBox;
        private IWebElement ClickOnsite;
        private IWebElement ClickOnline;
        private IWebElement StartDate;
        private IWebElement EndDate;
        private IWebElement SelectedDay;
        private IWebElement StartTime;
        private IWebElement EndTime;
        private IWebElement ClickCredit;
        private IWebElement EnterCharge;
        private IWebElement ClearTag;
        private IWebElement SaveButton;
        private IWebElement ShareSkillDeleteIcon;
        private IWebElement ClickYes;
        private string Message = "";
        public void renderAddTitleComponents()
        {
            try
            {
                Title = driver.FindElement(By.Name("title"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAddDescriptionComponents()
        {
            try
            {
                Description = driver.FindElement(By.Name("description"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderCategoryComponents()
        {
            try
            {
                Category = driver.FindElement(By.Name("categoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubCategoryComponents()
        {
            try
            {
                Subcategory = driver.FindElement(By.Name("subcategoryId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAddTagsComponent()
        {
            try
            {
                AddTags = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderServiceTypeComponent()
        {
            try
            {
                HourlyBasis = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
                ClickOneOff = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLocationTypeComponent()
        {
            try
            {
                ClickOnsite = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));
                ClickOnline = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailableDaysComponent()
        {
            try
            {
                StartDate = driver.FindElement(By.Name("startDate"));
                EndDate = driver.FindElement(By.Name("endDate"));
                SelectedDay = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
                StartTime = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
                EndTime = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
     public void renderSkillTrade()
        {
            try
            {
                ClickCredit = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderCredit()
        {
            try
            {
                EnterCharge = driver.FindElement(By.Name("charge"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderclearTag()
        {
            try
            {
                ClearTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span[2]/a[last()]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSaveButton()
        {
            try
            {
                SaveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void AddSkill(ShareSkillModel addShareSkill)
        {
            renderAddTitleComponents();
            renderAddDescriptionComponents();
            renderCategoryComponents();        
            renderAddTagsComponent();
            renderServiceTypeComponent();
            renderLocationTypeComponent();
            renderAvailableDaysComponent();
            Title.SendKeys(addShareSkill.title);
            Description.SendKeys(addShareSkill.description);
            Category.Click();
            Category.SendKeys(addShareSkill.category);
            Category.Click();
            renderSubCategoryComponents();
            Subcategory.Click();
            Thread.Sleep(1000);
            Subcategory.SendKeys(addShareSkill.subcategory);
            Subcategory.Click();
            Thread.Sleep(2000);
            AddTags.Click();
            Thread.Sleep(1000);
            AddTags.SendKeys(addShareSkill.tagone);
            AddTags.SendKeys(Keys.Enter);
            AddTags.SendKeys(addShareSkill.tagtwo);
            AddTags.SendKeys(Keys.Enter);
            ClickOneOff.Click();
            ClickOnsite.Click();
            StartDate.Click();
            StartDate.SendKeys(addShareSkill.startDate);
            Thread.Sleep(2000);
            EndDate.Click();
            EndDate.SendKeys(addShareSkill.endDate);
            SelectedDay.Click();
            StartTime.Click();
            Thread.Sleep(1000);
            StartTime.SendKeys(addShareSkill.startTime);
            Thread.Sleep(2000);
            EndTime.Click();
            EndTime.SendKeys(addShareSkill.endTime);
            Thread.Sleep(1000);
            renderSkillTrade();
            ClickCredit.Click();
            renderCredit();
            EnterCharge.Click();
            EnterCharge.SendKeys(addShareSkill.charge);
            Thread.Sleep(1000);
            renderSaveButton();
            SaveButton.Click();
            Thread.Sleep(8000);
        }
        public void UpdateSkill(ShareSkillModel updateShareSkill)
        {
            renderAddTitleComponents();
            renderAddDescriptionComponents();
            renderCategoryComponents();
            renderAddTagsComponent();
            renderAvailableDaysComponent();
            Title.Clear();
            Title.SendKeys(updateShareSkill.title);
            Description.Clear();
            Description.SendKeys(updateShareSkill.description);
            Thread.Sleep(1000);
            Category.Click();
            Thread.Sleep(1000);
            Category.SendKeys(updateShareSkill.category);
            Category.Click();
            Thread.Sleep(1000);
            renderSubCategoryComponents();
            Subcategory.Click();
            Thread.Sleep(1000);
            Subcategory.SendKeys(updateShareSkill.subcategory);
            Subcategory.Click();
            Thread.Sleep(2000);
            renderclearTag();
            ClearTag.Click();
            Thread.Sleep(1000);
            AddTags.SendKeys(updateShareSkill.tagone);
            AddTags.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            AddTags.SendKeys(updateShareSkill.tagtwo);
            AddTags.SendKeys(Keys.Enter);
            StartDate.Click();
            StartDate.SendKeys(updateShareSkill.startDate);
            Thread.Sleep(2000);
            EndDate.Click();
            EndDate.SendKeys(updateShareSkill.endDate);
            SelectedDay.Click();
            StartTime.Click();
            Thread.Sleep(1000);
            StartTime.SendKeys(updateShareSkill.startTime);
            Thread.Sleep(2000);
            EndTime.Click();
            EndTime.SendKeys(updateShareSkill.endTime);
            Thread.Sleep(1000);
            renderSkillTrade();
            ClickCredit.Click();
            renderCredit();
            EnterCharge.Click();
            EnterCharge.SendKeys(updateShareSkill.charge);
            Thread.Sleep(1000);
            renderSaveButton();
            SaveButton.Click();
        }
        public  void renderDeleteIcon()
        {
            try
            {
                ShareSkillDeleteIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteYes()
        { 
             try 
            {
               
                ClickYes = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
           public void DeleteShareSkill()
        {
            renderDeleteIcon();
            ShareSkillDeleteIcon.Click();
            Thread.Sleep(2000);
            renderDeleteYes();
            ClickYes.Click();
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
        public string GetMessageBoxText()
        {
            renderAddMessage();
            //get the text of the message element
            string Message = messageBox.Text;
            return Message;
        }

    }
}

