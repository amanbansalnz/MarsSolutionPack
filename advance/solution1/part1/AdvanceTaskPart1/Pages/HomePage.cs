using AdvanceTaskPart1.Pages.Components;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Steps;
using AdvanceTaskPart1.Utils;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.Pages
{
    public class HomePage : CommonDriver
    {
        private static IWebElement checkUser;
        private static IWebElement profileTab;
        private static IWebElement shareSkill;
        private static IWebElement searchSkill;
        private static IWebElement notification;
        private static IWebElement dashboardNotification;

        public void clickProfileTab()
        {
            renderProfileTabComponent();
            profileTab.Click();
        }
        public void renderProfileTabComponent()
        {
            try
            {
                profileTab = driver.FindElement(By.LinkText("Profile"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderShareSkillComponent()
        {
            try
            {
                shareSkill = driver.FindElement(By.XPath("//a[contains(text(),'Share Skill')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSearchSkillComponent()
        {
            try
            {
                searchSkill = driver.FindElement(By.XPath("//i[@class='search link icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickShareSkill()
        {
            renderShareSkillComponent();
            shareSkill.Click();
        }
        public void clickSearchSkill()
        {
            renderSearchSkillComponent();
            searchSkill.Click();
        }
        public void clickNotificationPanel()
        {
            renderNotificationComponent();
            notification.Click();
            dashboardNotification.Click();
        }
        public void renderNotificationComponent()
        {
            try
            {
                notification = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
                dashboardNotification = driver.FindElement(By.LinkText("Dashboard"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderUserComponent()
        {
            try
            {
                checkUser = driver.FindElement(By.XPath("//span[contains(@class,'item ui')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public String getUserName()
        {
            try
            {
                renderUserComponent();
                Thread.Sleep(3000);
                string user = checkUser.Text;
                Console.WriteLine(user);
                return checkUser.Text;
            }
            catch (Exception ex)
            {
                renderUserComponent();
                Thread.Sleep(3000);
                Console.WriteLine(checkUser.Text);
                return ex.Message;
            }
        }

    }
}
