using AdvanceTask_Sprint2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Components.ProfilePageTabComponents
{
    public class SkillComponent : BaseSetup
    {
        private IWebElement addNewSkillButton;
        private IWebElement pencilIcon;

        public void renderComponents()
        {
            try
            {
                addNewSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
                pencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickAddSkill()
        {
            renderComponents();
            addNewSkillButton.Click();
        }
        public void clickUpdateSkill()

        {
            renderComponents();
            pencilIcon.Click();
        }
    }
}





