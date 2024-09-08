using OpenQA.Selenium;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverview
{
    public class ProfileAboutMe :Base
    {
#pragma warning disable
        private IWebElement enterFirstName;
        private IWebElement enterLastName;
        private IWebElement saveButton;
        private IWebElement addedUsername;
        private IWebElement availabilityType;
        private IWebElement availabilityHours;
        private IWebElement availabilityTarget;
        private IWebElement addedAvailability;
        private IWebElement addedHours;
        private IWebElement addedEarnTarget;
        private IWebElement message;
        public void renderComponents()
        {
            try
            {
                enterFirstName = driver.FindElement(By.Name("firstName"));
                enterLastName = driver.FindElement(By.Name("lastName"));
                saveButton = driver.FindElement(By.XPath("//button[normalize-space()='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailabilityComponent()
        {
            availabilityType = driver.FindElement(By.Name("availabiltyType"));
        }
        public void renderHoursComponent()
        {
            availabilityHours = driver.FindElement(By.Name("availabiltyHour"));
        }
        public void renderEarnTargetComponent()
        {
            availabilityTarget = driver.FindElement(By.Name("availabiltyTarget"));
        }
        public void renderAddTestComponent()
        {
            try
            {
                addedUsername = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailabilityTestComponent()
        {
            addedAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
        }
        public void renderHoursTestComponent()
        {
            addedHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div"));
        }
        public void renderEarnTargetTestComponent()
        {
            addedEarnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div"));
        }
        public void renderMessageComponent()
        {
            message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void usernameAvailabilityDetails(ProfileAboutMeTestModel data)
        {
            Thread.Sleep(2000);
            renderComponents();
            enterFirstName.Clear();
            enterLastName.SendKeys(data.firstName);
            enterLastName.Clear();
            enterLastName.SendKeys(data.lastName);
            saveButton.Click();
        }
        public string getVerifyUsername()
        {
            renderAddTestComponent();
            return addedUsername.Text;
        }
        public void addAndUpdateAvailabilityDetails(ProfileAboutMeTestModel data)
        {
            renderAvailabilityComponent();
            availabilityType.SendKeys(data.availability);
        }
       
        public string getSuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 24);
            renderMessageComponent();
            return message.Text;
        }
        public void addAndUpdateHoursDetails(ProfileAboutMeTestModel data)
        {
            renderHoursComponent();
            availabilityHours.SendKeys(data.hours);
        }
       
        public void addAndUpdateEarnTargetDetails(ProfileAboutMeTestModel data)
        {
            Thread.Sleep(1000);
            renderEarnTargetComponent();
            availabilityTarget.SendKeys(data.earnTarget);
        }
    }
}
    

