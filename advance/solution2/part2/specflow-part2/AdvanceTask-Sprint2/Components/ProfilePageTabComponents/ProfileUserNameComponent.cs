using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Components.ProfilePageTabComponents
{
    public class ProfileUserNameComponent : BaseSetup
    {
        private IWebElement AddFirstName;
        private IWebElement AddLastName;
        private IWebElement SaveButton;
        private IWebElement availabilityDropdown;
        private IWebElement availabilityHours;
        private IWebElement availabilityTarget;
        private IWebElement messageBox;
        private string Message = "";
        public void renderAddComponents()
        {
            try
            {
                AddFirstName = driver.FindElement(By.Name("firstName"));
                AddLastName = driver.FindElement(By.Name("lastName"));
                SaveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button"));
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

        public void renderAvailability()
        {
            try
            {
                availabilityDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void renderHours()
        {
            try
            {
                availabilityHours = driver.FindElement(By.Name("availabiltyHour"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderTarget()
        {
            try
            {
                availabilityTarget = driver.FindElement(By.Name("availabiltyTarget"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void AddFirstLastName(UserNameModel username)
        {
            renderAddComponents();
            AddFirstName.Clear();
            AddFirstName.SendKeys(username.firstName);
            AddLastName.Clear();
            AddLastName.SendKeys(username.lastName);
            Thread.Sleep(1000);
            SaveButton.Click();
            Thread.Sleep(3000);
        }
        public void AddAvailability(UserNameModel availability)
        {
            renderAvailability();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement availabilityDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select")));
            availabilityDropdown.Click();
            Thread.Sleep(2000);
            availabilityDropdown.SendKeys(availability.Time);
            availabilityDropdown.Click();
            Thread.Sleep(2000);
        }
        public void AddHours(UserNameModel hours)
        {
            renderHours();
            availabilityHours.Click();
            Thread.Sleep(2000);
            availabilityHours.SendKeys(hours.Hours);
            availabilityHours.Click();
            Thread.Sleep(2000);
        }
        public void AddTarget(UserNameModel target)
        {
            renderTarget();
            availabilityTarget.Click();
            Thread.Sleep(1000);
            availabilityTarget.SendKeys(target.Target);
            availabilityTarget.Click();
            Thread.Sleep(2000);
        }
        public string GetMessageBoxText()
        {
            renderAddMessage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement messageBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='ns-box-inner']")));
            //get the text of the message element
            string Message = messageBox.Text;
            return Message;
        }

    }
}

