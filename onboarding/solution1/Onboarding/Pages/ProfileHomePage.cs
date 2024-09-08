using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectMars.Utilities;

namespace SpecFlowProjectMars.Pages
{
    public class ProfileHomePage: CommonDriver
    {
        
        public void NavigateToLanguagePanel()
        {
            
            try
            {
                //WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Languages']", 5);
                //navigate to language 
                IWebElement languageTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                languageTab.Click();
            }
            catch(Exception ex) 
            {
                Assert.Fail("Panel not clickable");
            }
            
        }
        public void NavigateToSkillsPanel()
        {
            try
            {
                //WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Skills']", 5);
                //navigate to language 
                IWebElement skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
                skillsTab.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Panel not clickable");
            }
        }

        public void VerifyLoggedInUser()
        {
            Thread.Sleep(1000);
            //Check if user has loggedin Successfully
            IWebElement checkUser = driver.FindElement(By.XPath("//span[contains(text(),'Hi')]"));
            if (checkUser.Text == "Hi Geothy")
            {

                Console.WriteLine("Logged in");

            }
            else
            {
                Console.WriteLine("Not Logged in");
            }
        }
    }
}
