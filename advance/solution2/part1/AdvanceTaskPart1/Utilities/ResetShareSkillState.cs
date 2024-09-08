using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Utilities
{
    public class ResetShareSkillState : BaseSetup
    {

        public void ClickOnManageListing()
        {

            IWebElement ClickonManageListings = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            ClickonManageListings.Click();
        }

        public void DeleteAllSkills()
        {
            try
            {
                var skillDeleteIcons = driver.FindElements(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));

                if (skillDeleteIcons.Count == 0)
                {
                    Console.WriteLine("No skills to delete");
                }
                else
                {
                    for (int i = 0; i < skillDeleteIcons.Count; i++)
                    {
                        skillDeleteIcons[i].Click();
                        var yesButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
                        yesButton.Click();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

}
