using Advanced_Task_1.Components.ProfilePageTabComponents;
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
    public class ActualState : BaseSetup
    {
        public void TableState()
        {
            IWebElement languageTable = driver.FindElement(By.XPath("//table[@class='ui fixed table']"));
            IList<IWebElement> languageTableRows = languageTable.FindElements(By.TagName("tr"));

            int rowCount = languageTableRows.Count;

            for (int i = rowCount - 1; i >=1; i--)
            {
                try
                {
                    IWebElement row = languageTableRows[i];
                    IWebElement deleteicon = row.FindElement(By.XPath("//i[@class='remove icon']"));
                   WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                   wait.Until(ExpectedConditions.ElementToBeClickable(deleteicon));
                    Console.WriteLine($"Deleting row {i}");
                    deleteicon.Click();

                    Thread.Sleep(5000);
                }
                catch (StaleElementReferenceException) { /* Handle exception or continue the loop */ }
            }

        }
    }
}
