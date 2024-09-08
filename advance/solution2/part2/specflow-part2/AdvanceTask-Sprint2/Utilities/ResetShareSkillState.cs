using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Utilities
{
    public class ResetShareSkillState : BaseSetup
    {
        private IWebElement messageBox;
        private string Message = "";
        public void ClickOnManageListing()
        {
            IWebElement ClickonManageListings = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            ClickonManageListings.Click();
        }

        public void DeleteAllSkills()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")));
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
                           
                            wait.Until(ExpectedConditions.ElementToBeClickable(deleteIcon));
                            deleteIcon.Click();
                            var yesButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div/div[3]/button[2]")));
                            yesButton.Click();
                        }
                        catch (WebDriverTimeoutException)
                        {
                          
                            Console.WriteLine("Timeout waiting for deleteIcon to be clickable");
                        }
                        catch (Exception ex)
                        {
                           
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
        public void renderAddMessage()
        {
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (StaleElementReferenceException)
            {           
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while finding the message box: {ex.Message}");            
            }
        }

        public string GetMessageBoxText()
        {
            renderAddMessage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box-inner']")));
            //get the text of the message element
            string Message = messageBox.Text;
            return Message;
        }

    }
}