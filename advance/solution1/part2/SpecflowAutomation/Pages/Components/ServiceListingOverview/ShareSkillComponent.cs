using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using TechTalk.SpecFlow.Assist;

namespace SpecflowAutomation.Pages.Components.ServiceListingOverview
{
    public class ShareSkillComponent:Base
    {
#pragma warning disable
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement chooseCategory;
        private IWebElement chooseSubcategory;
        private IWebElement addTag;
        private IWebElement serviceTypeBtn;
        private IWebElement locationTypeBtn;
        private IWebElement availableDaysStartDate;
        private IWebElement availableDaysEndDate;
        private IWebElement availableDays;
        private IWebElement selectStartTime;
        private IWebElement selectEndTime;
        private IWebElement skillTradeBtn;
        private IWebElement skillExchangeTag;
        private IWebElement activeButton;
        private IWebElement saveButton;
        private IWebElement messageBox;
        private IWebElement availableSunday;
        private IWebElement addedShareSkillCategory;
        private IWebElement editedShareSkillCategory;
        private IWebElement cancelButton;
        private IWebElement yesBtn;
        
        public void renderShareskillTitleComponent()
        {
           try
           {
              addTitle = driver.FindElement(By.Name("title"));
           }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderShareSkillDataComponents() 
        {
            addDescription = driver.FindElement(By.Name("description"));
            chooseCategory = driver.FindElement(By.Name("categoryId"));
        }
        public void renderSubcategoryComponent()
        {
            chooseSubcategory = driver.FindElement(By.Name("subcategoryId"));
        }
        public void renderTagComponent()
        {
            addTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        }
        public void renderTypeComponents()
        {
            serviceTypeBtn = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
            locationTypeBtn = driver.FindElement(By.Name("locationType"));
        }
        public void renderDaysComponents()
        {
            availableDaysStartDate = driver.FindElement(By.Name("startDate"));
            availableDaysEndDate = driver.FindElement(By.Name("endDate"));
        }
        public void renderTimeComponents()
        {
            availableSunday = driver.FindElement(By.Name("Available"));
            selectStartTime = driver.FindElement(By.Name("StartTime"));
            selectEndTime = driver.FindElement(By.Name("EndTime"));
        }
        public void renderTradeComponents()
        {
            skillTradeBtn = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
        }
        public void renderSkillExchangeComponent()
        {
            skillExchangeTag = driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
        }
        public void renderActiveComponent()
        {
            activeButton = driver.FindElement(By.Name("isActive"));
        }
        public void renderSaveComponent()
        {
            saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        }
        public void renderCancelComponent()
        {
            cancelButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[2]"));
        }
        public void renderAddedShareSkill()
        {
            addedShareSkillCategory = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        }
        public void renderUpdatedShareSkill()
        {
            editedShareSkillCategory = driver.FindElement(By.XPath("//td[normalize-space()='Music & Audio']"));
        }
        public void renderErrorMessageBox()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void renderAlertWindowComponent()
        {
            yesBtn = driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));
        }

        public void clearExistingData()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait for the delete icons to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")));

                // Find all the delete icons for skills
                var skillDeleteIcons = driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i"));

                if (skillDeleteIcons.Count == 0)
                {
                    Console.WriteLine("No skills to delete");
                }
                else
                {
                    // Iterate through each delete icon and click it
                    foreach (var deleteIcon in skillDeleteIcons)
                    {
                        try
                        {
                            // Wait for the delete icon to be clickable
                            wait.Until(ExpectedConditions.ElementToBeClickable(deleteIcon));

                            // Click the delete icon
                            deleteIcon.Click();

                            // Wait for the 'Yes' button to be clickable
                            var yesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div/div[3]/button[2]")));

                            // Click the 'Yes' button to confirm the deletion
                            yesButton.Click();
                                                       
                        }
                        catch (WebDriverTimeoutException)
                        {
                            // Handle timeout specifically for deleteIcon click
                            Console.WriteLine("Timeout waiting for deleteIcon to be clickable");
                        }
                        catch (Exception ex)
                        {
                            // Handle other exceptions during deleteIcon click
                            Console.WriteLine($"Error while deleting skill: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }
        public void addShareSkill(ShareSkillTestModel addSkill)
        {
            Thread.Sleep(2000);
            renderShareskillTitleComponent();
            addTitle.SendKeys(addSkill.title);
            renderShareSkillDataComponents();
            addDescription.SendKeys(addSkill.description);
            chooseCategory.SendKeys(addSkill.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(addSkill.subcategory);
        }
        public void addShareSkillTag(ShareSkillTestModel addSkill)
        {
            renderTagComponent();
            addTag.SendKeys(addSkill.tags);
            addTag.SendKeys(Keys.Enter);
        }
        public void addShareSkillType()
        {
            Thread.Sleep(2000);
            renderTypeComponents();
            serviceTypeBtn.Click();
            locationTypeBtn.Click();
        }
        public void addShareSkillDays(ShareSkillTestModel addSkill)
        {
            renderDaysComponents();
            availableDaysStartDate.SendKeys(addSkill.startDate);
            availableDaysEndDate.SendKeys(addSkill.endDate);
        }
        public void addShareSkillTime(ShareSkillTestModel addSkill)
        {
            renderTimeComponents();
            availableSunday.Click();
            selectStartTime.SendKeys(addSkill.startTime);
            selectEndTime.SendKeys(addSkill.endTime);
        }
        public void addShareSkillTrade(ShareSkillTestModel addSkill)
        {
            renderTradeComponents();
            skillTradeBtn.Click();
            Thread.Sleep(2000);
            renderSkillExchangeComponent();
            skillExchangeTag.SendKeys(addSkill.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
        }
        public void addShareSkillActive()
        {
            renderActiveComponent();
            activeButton.Click();
            renderSaveComponent();
            saveButton.SendKeys(Keys.Enter);
            saveButton.Submit();
        }
        public void newShareSkill(ShareSkillTestModel addSkill)
        {
            addShareSkill(addSkill);
            addShareSkillTag(addSkill);
            addShareSkillType();
            addShareSkillDays(addSkill);
            addShareSkillTime(addSkill);
            addShareSkillTrade(addSkill);
            addShareSkillActive();
        }
        public string verifyAddedShareSkill()
        {
            Thread.Sleep(2000);
            renderAddedShareSkill();
            return addedShareSkillCategory.Text;
        }
        public void EditShareSkill(ShareSkillTestModel addSkill)
        {
            renderShareskillTitleComponent();
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(addSkill.title);
            renderShareSkillDataComponents();
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(addSkill.description);
            chooseCategory.SendKeys(addSkill.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(addSkill.subcategory);
            renderTagComponent();
            addTag.SendKeys(addSkill.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            serviceTypeBtn.Click();
            locationTypeBtn.Click();
            renderDaysComponents();
            availableDaysStartDate.SendKeys(addSkill.startDate);
            availableDaysEndDate.SendKeys(addSkill.endDate);
            renderTimeComponents();
            availableSunday.Click();
            selectStartTime.SendKeys(addSkill.startTime);
            selectEndTime.SendKeys(addSkill.endTime);
            renderTradeComponents();
            skillTradeBtn.Click();
            renderSkillExchangeComponent();
            skillExchangeTag.SendKeys(addSkill.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderActiveComponent();
            activeButton.Click();
            renderSaveComponent();
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            saveButton.Submit();

        }
        public string verifyEditedShareSkill()
        {
            Thread.Sleep(2000);
            renderUpdatedShareSkill();
            return editedShareSkillCategory.Text;
        }
        public void shareSkillAddNegative(ShareSkillTestModel addSkill)
        {
            renderShareskillTitleComponent();
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            renderShareSkillDataComponents();
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            chooseCategory.SendKeys(addSkill.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(addSkill.subcategory);
            renderTagComponent();
            addTag.SendKeys(addSkill.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            serviceTypeBtn.Click();
            locationTypeBtn.Click();
            renderDaysComponents();
            availableDaysStartDate.SendKeys(addSkill.startDate);
            availableDaysEndDate.SendKeys(addSkill.endDate);
            renderTimeComponents();
            availableSunday.Click();
            selectStartTime.SendKeys(addSkill.startTime);
            selectEndTime.SendKeys(addSkill.endTime);
            renderTradeComponents();
            skillTradeBtn.Click();
            renderSkillExchangeComponent();
            skillExchangeTag.SendKeys(addSkill.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderActiveComponent();
            activeButton.Click();
            renderSaveComponent();
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelComponent();
            cancelButton.Click();
        }
        public string verifyNegativeShareSkill()
        {
            Thread.Sleep(2000);
            renderErrorMessageBox();
            return messageBox.Text;
        }
        public void shareSkillUpdateNegative(ShareSkillTestModel addSkill)
        {
            renderShareskillTitleComponent();
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(addSkill.title);
            renderShareSkillDataComponents();
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(addSkill.description);
            chooseCategory.SendKeys(addSkill.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(addSkill.subcategory);
            renderTagComponent();
            addTag.SendKeys(addSkill.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            serviceTypeBtn.Click();
            locationTypeBtn.Click();
            renderDaysComponents();
            availableDaysStartDate.SendKeys(addSkill.startDate);
            availableDaysEndDate.SendKeys(addSkill.endDate);
            renderTimeComponents();
            availableSunday.Click();
            selectStartTime.SendKeys(addSkill.startTime);
            selectEndTime.SendKeys(addSkill.endTime);
            renderTradeComponents();
            skillTradeBtn.Click();
            renderSkillExchangeComponent();
            skillExchangeTag.SendKeys(addSkill.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderActiveComponent();
            activeButton.Click();
            renderSaveComponent();
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelComponent();
            cancelButton.Click();
        }
        public string verifyNegativeShareSkillUpdate()
        {
            Thread.Sleep(2000);
            renderErrorMessageBox();
            return messageBox.Text;
        }
    }
}


