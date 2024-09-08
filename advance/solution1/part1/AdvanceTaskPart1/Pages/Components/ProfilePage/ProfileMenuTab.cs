using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileMenuTab : CommonDriver
    {
        private static IWebElement languagesTab;
        private static IWebElement skillsTab;
        private static IReadOnlyList<IWebElement> delIcon;
        public void renderProfileTabComponents()
        {
            try
            {
                languagesTab = driver.FindElement(By.XPath("//a[text()='Languages']"));
                skillsTab = driver.FindElement(By.XPath("//a[text()='Skills']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderDeleteIcon()
        {
            try
            {
                Thread.Sleep(2000);
                delIcon = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void clickLangaugesTab()
        {
            renderProfileTabComponents();
            languagesTab.Click();
        }
        public void clickSkillsTab()
        {
            renderProfileTabComponents();
            skillsTab.Click();
            //  Thread.Sleep(1000);
        }
        public void ClearLangData()
        {
            try
            {
                clickLangaugesTab();
                renderDeleteIcon();
                foreach (var button in delIcon)
                {
                    Thread.Sleep(1000);
                    WaitUtils.WaitToBeClickable(driver, "xpath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i", 20);
                    button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                clickLangaugesTab();
                renderDeleteIcon();
                foreach (var button1 in delIcon)
                {
                    Thread.Sleep(100);
                    WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button1.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }

        }
        public void ClearSkillData()
        {
            try
            {
                clickSkillsTab();
                Thread.Sleep(2000);
                renderDeleteIcon();
                foreach (var button in delIcon)
                {
                    Thread.Sleep(1000);
                    button.Click();
                }
            }
            catch (StaleElementReferenceException e)
            {
                clickSkillsTab();
                renderDeleteIcon();
                foreach (var button1 in delIcon)
                {
                    Thread.Sleep(1000);
                    // WaitUtils.WaitToBeClickable(driver, "cssselector", "i[class='remove icon']", 20);
                    button1.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nothing to delete");
            }
        }
    }
}
