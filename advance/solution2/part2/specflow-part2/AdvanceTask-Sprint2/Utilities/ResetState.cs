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
    public class ResetState : BaseSetup
   {
        public void DeleteRows()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                while (true)
                {
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));

                    if (deleteButtons.Count == 0)
                    {
                       
                        break;
                    }

                    foreach (var button in deleteButtons)
                    {
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(button)).Click();
                            Thread.Sleep(5000);
                        }
                        catch (StaleElementReferenceException)
                        {
                            // Handle the exception by re-finding the element or logging the issue
                        }
                    }
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No items to delete");
            }
        }

    }
}

