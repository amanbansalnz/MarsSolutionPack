using AdvanceTask_Sprint2.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.Components.ProfilePageTabComponents
{
    public class LanguageComponent : BaseSetup
    {
        private IWebElement AddNew;
        private IWebElement PencilIcon;
        public void renderComponents()
        {
            try
            {
                AddNew = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
             }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderupdateComponents()
        {
            try
            {
               PencilIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickAddLanguage()
        {
            renderComponents();
            AddNew.Click();
        }
        public void clickUpdateLanguage()
        {
            renderupdateComponents();
            Thread.Sleep(2000);
            PencilIcon.Click();
        }

    }
}


