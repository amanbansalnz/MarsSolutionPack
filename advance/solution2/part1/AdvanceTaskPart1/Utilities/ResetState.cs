using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Utilities
{
    public class ResetState : BaseSetup
    {
        public void Deleterows()
            {

        try
            {

                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }

}
            catch (NoSuchElementException)
            { Console.WriteLine("no items to delete"); }
    }
}
}
