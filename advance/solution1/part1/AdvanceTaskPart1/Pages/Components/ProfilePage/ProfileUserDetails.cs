using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileUserDetails : CommonDriver
    {
        private IWebElement editIconAT;
        private IWebElement editIconAH;
        private IWebElement editIconET;
        private IWebElement availableTime;
        private IWebElement aTimeSelect;
        private IWebElement availableHours;
        private IWebElement earnTarget;

        public void renderEditIcon()
        {
            Thread.Sleep(2000);
            editIconAT = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            editIconAH = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            editIconET = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));

        }
        public void renderAvailableTime()
        {
            try
            {
                availableTime = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderAvailableHours()
        {
            try
            {
                availableHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            }
            catch (StaleElementReferenceException e)
            {
                availableHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderEarnTarget()
        {
            try
            {
                earnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void editAvailableTime(string aTime)
        {
            Thread.Sleep(1000);
            renderEditIcon();
            editIconAT.Click();
            renderAvailableTime();
            availableTime.Click();
            availableTime.SendKeys(aTime);
            renderAvailableTime();
            availableTime.Click();
            Thread.Sleep(2000);
        }
        public void editAvailableHours(string aHours)
        {
            renderEditIcon();
            editIconAH.Click();
            renderAvailableHours();
            availableHours.Click();
            availableHours.SendKeys(aHours);
            renderAvailableHours();
            availableHours.Click();
            Thread.Sleep(2000);
        }
        public void editeTarget(string eTarget)
        {
            renderEditIcon();
            editIconET.Click();
            renderEarnTarget();
            earnTarget.Click();
            earnTarget.SendKeys(eTarget);
            renderEarnTarget();
            earnTarget.Click();
            Thread.Sleep(2000);
        }
    }
}
