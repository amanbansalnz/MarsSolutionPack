using OpenQA.Selenium;
using SpecflowAutomation.TestModel;
using SpecflowAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAutomation.Pages.Components.ProfileOverview
{
    public class DescriptionComponent : Base
    {
#pragma warning disable
        private IWebElement enterDescription;
        private IWebElement saveBtn;
        private IWebElement addedDescription;
        private IWebElement messageBox;
        private IWebElement deletePopupMessage;
        public void renderDescriptionComponents()
        {
            try
            {
                enterDescription = driver.FindElement(By.Name("value"));
                saveBtn = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDescriptionTestComponent()
        {
            addedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        }
        public void renderMessageBoxTestComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void renderDeleteComponent()
        {
            deletePopupMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
        }
        public void addAndUpdateDescriptionDetails(DescriptionTestModel data)
        {
            renderDescriptionComponents();
            enterDescription.Clear();
            enterDescription.SendKeys(data.textArea);
            saveBtn.Click();
        }
        public void addNegativedes(DescriptionTestModel data)
        {
            Thread.Sleep(2000);
            renderDescriptionComponents();
            enterDescription.SendKeys(Keys.Control + "A");
            enterDescription.SendKeys(Keys.Delete);
            enterDescription.SendKeys(data.textArea);
            saveBtn.Click();
        }
        public string SuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageBoxTestComponent();
            //Saving error or Success message
            return messageBox.Text;
        }
        public void deleteDesc(DescriptionTestModel data)
        {
            renderDescriptionComponents();
            enterDescription.SendKeys(Keys.Control + "A");
            enterDescription.SendKeys(Keys.Delete);
            enterDescription.SendKeys(data.textArea);
            saveBtn.Click();
        }
    }
}
