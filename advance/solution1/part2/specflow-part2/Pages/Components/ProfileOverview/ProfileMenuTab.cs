using OpenQA.Selenium;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverview
{
    public class ProfileMenuTab:Base
    {
#pragma warning disable
        private IWebElement userNameDropdownIcon;
        private IWebElement availabilityEditBtn;
        private IWebElement hoursEditBtn;
        private IWebElement earnTargetEditBtn;
        private IWebElement descriptionEditIcon;
        private IWebElement languagesTab;
        private IWebElement languageEditIcon;
        private IWebElement languageDeleteIcon;
        private IWebElement shareSkillTab;
        private IWebElement manageListingTab;
        private IWebElement manageListing;
        private IWebElement manageListingEditIcon;
        
        public void renderComponents()
        {
            try
            {
                userNameDropdownIcon = driver.FindElement(By.XPath("//div[@class='title']//i[@class='dropdown icon']"));
                availabilityEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[2]/div/span/i"));
                hoursEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div/div/div[3]//div[3]/div/span/i"));
                earnTargetEditBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[4]/div/span/i"));
                descriptionEditIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLanguageTabComponent()
        {
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEditLanguageComponent()
        {
            languageEditIcon = driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]"));
        }
        public void renderDeleteComponent()
        {
            languageDeleteIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[2]/i"));
        }
        public void renderShareSkillComponent()
        {
            shareSkillTab = driver.FindElement(By.XPath("//a[normalize-space()='Share Skill']"));
        }
        public void renderManageListingTab()
        {
            manageListingTab = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/section[1]/div/a[3]"));
        }
        public void renderProfileManageListingComponent()
        {
            manageListing = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        }
        public void renderManageListingEditIcon()
        {
            manageListingEditIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        }
       
        public void clickUserNameIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='title']//i[@class='dropdown icon']", 20);
            renderComponents();
            userNameDropdownIcon.Click();
        }
        public void clickAvailabilityEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[2]/div/span/i", 20);
            renderComponents();
            availabilityEditBtn.Click();
        }
        public void clickHoursEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div/div/div[3]//div[3]/div/span/i", 20);
            renderComponents();
            hoursEditBtn.Click();
        }
        public void clickEarnTargetEditBtn()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]//section[2]//div[2]//div[3]//div[4]/div/span/i", 20);
            renderComponents();
            earnTargetEditBtn.Click();
        }
        public void clickDescriptionEditIcon()
        {
            Thread.Sleep(2000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 20);
            renderComponents();
            descriptionEditIcon.Click();
        }
        public void clickLanguagesTab()
        {
            renderLanguageTabComponent();
            languagesTab.Click();
        }
        public void clickLanguageEditIcon()
        {
            renderEditLanguageComponent();
            languageEditIcon.Click();
        }
        public void clickDeleteIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr[last()]/td[3]/span[2]/i", 20);
            renderDeleteComponent();
            languageDeleteIcon.Click();
        }
        public void clickShareSkillTab()
        {
            Thread.Sleep(2000);
            renderShareSkillComponent();
            shareSkillTab.Click();
        }
        public void clickManageListingTab()
        {
            Thread.Sleep(2000);
            renderManageListingTab();
            manageListingTab.Click();
            Wait.WaitToBeVisible(driver, "XPath", ".//i[@class='remove icon']", 20);
        }
        public void clickManageListing()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 20);
            renderProfileManageListingComponent();
            manageListing.Click();
        }
        public void clickManageListingEditIcon()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 20);
            renderManageListingEditIcon();
            manageListingEditIcon.Click();
        }
        
    }
}

    

