using AdvanceTask_Sprint2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Components.ProfilePageTabComponents
{
    public class ProfilePageTabsComponents : BaseSetup
    {

        private IWebElement languagesTab;
        private IWebElement skillsTab;
        private IWebElement userNameButton;
        private IWebElement availabilityPencilIcon;
        private IWebElement HourspencilIcon;
        private IWebElement earnTargetPencilIcon;
        private IWebElement shareSkillButton;
        private IWebElement UpdateshareSkillIcon;
        private IWebElement clickSearch;
        private IWebElement clickNotification;
        private IWebElement clickDashboard;
        public void renderComponents()
        {
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                userNameButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i"));
                availabilityPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                HourspencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
                earnTargetPencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderShareskill()
        {
            try
            {
                shareSkillButton = driver.FindElement(By.XPath("//a[@class='ui basic green button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderUpdateShareSkillIcon()
        {
            try
            {
                UpdateshareSkillIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[8]/div/button[2]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderClicksearchicon()
        {
            try
            {

                clickSearch = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderClickNotification()
        {
            try
            {

                clickNotification = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderClickDashboard()
        {
            try
            {

                clickDashboard = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[1]"));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickLangaugesTab()
        {
            renderComponents();
            languagesTab.Click();
        }
        public void clickSkillsTab()
        {
            renderComponents();
            skillsTab.Click();
        }

        public void clickUserNameButton()
        {
            renderComponents();
            userNameButton.Click();
            Thread.Sleep(1000);
        }
        public void clickAvailabilityPencilIcon()
        {
            renderComponents();
            availabilityPencilIcon.Click();

        }
        public void clickHoursWeekPencilIcon()
        {
            renderComponents();
            HourspencilIcon.Click();
        }
        public void clickEarnTargetPencilIcon()
        {
            renderComponents();
            earnTargetPencilIcon.Click();
        }
        public void clickShareSkillButton()
        {
            renderShareskill();
            shareSkillButton.Click();
            Thread.Sleep(1000);
        }
        public void clickupdateShareSkill()
        {
            renderUpdateShareSkillIcon();
            UpdateshareSkillIcon.Click();

        }
        public void clickSearchIcon()
        {
            renderClicksearchicon();
            clickSearch.Click();
        }

        public void clickNotificationTab()
        {
            renderClickNotification();
            clickNotification.Click();
        }

        public void clickDashboardTab()
        {
            renderClickDashboard();
            clickDashboard.Click();

        }

    }
}