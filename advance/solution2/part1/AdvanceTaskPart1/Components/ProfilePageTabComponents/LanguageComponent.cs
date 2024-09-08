using Advanced_Task_1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Components.ProfilePageTabComponents
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
                renderComponents();
               Thread.Sleep(2000);
                PencilIcon.Click();
        }
       
        }
    }


