using Advanced_Task_1.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.Components.ProfilePageTabComponents
{
    public class NotificationsComponents : BaseSetup
    {
        private IWebElement ClickSeeAll;
        private IWebElement ClickLoadMore;
        private IWebElement ClickSeeLess;
        private IWebElement ClickSelectAll;
        private IWebElement ClickUnselectAll;
        private IWebElement ClickMarkAsRead;
        private IWebElement messageBox;
        private IWebElement SelectNotification;
        private IWebElement ClickDeletetNotification;
        private string message = "";
        public void renderNotificationComponents()
        {
            try
            {
                ClickSeeAll = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div/div/span/div/div[2]/div/center"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLoadMoreCompnents()
        {
            try
            {
                ClickLoadMore = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSeeLessComponents()
        {
            try
            {
                ClickSeeLess = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[11]/div[1]/center/a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSelectAllComponents()
        {
            try
            {
                ClickSelectAll = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[1]/i"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderUnselectAllComponents()
        {
            try
            {
                ClickUnselectAll = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderMarkAsReadComponents()
        {
            try
            {
                ClickMarkAsRead = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSelectNotificationsComponents()
        {
            try
            {
                SelectNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void renderDeleteComponents()
        {
            try
            {
                ClickDeletetNotification = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderAddMessage()
        {
            try
            {
                messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool VerifyClickSeeAll()
        {
            try
            {
                renderNotificationComponents();
                ClickSeeAll.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool VerifyClickLoadMore()
        {
            try
            {
                renderLoadMoreCompnents();
                ClickLoadMore.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool VerifyClickShowLess()
        {
            try
            {
                renderLoadMoreCompnents();
                ClickLoadMore.Click();
                renderSeeLessComponents();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[11]/div[1]/center/a")));
                ClickSeeLess.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool VerifyClickSelectAll()
        {
            try
            {
                renderSelectAllComponents();
                ClickSelectAll.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool VerifyClickUnselectAll()
        {
            try
            {
                renderSelectAllComponents();
                ClickSelectAll.Click();
                renderUnselectAllComponents();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[2]")));
                ClickUnselectAll.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool VerifyMarkSelectionAsRead()
        {
            try
            {
                renderSelectAllComponents();
                ClickSelectAll.Click();
                renderMarkAsReadComponents();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]")));
                ClickMarkAsRead.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool VerifyDeleteSelectionButton()
        {
            try
            {
                renderSelectNotificationsComponents();
                SelectNotification.Click();
                renderDeleteComponents();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]")));
                ClickDeletetNotification.Click();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public string GetMessageBoxText()
        {
            try
            {
                renderAddMessage();
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='ns-box-inner']")));
                if (messageBox != null)
                {
                    string Message = messageBox.Text;
                    return Message;
                }
                else
                {
                    return "Message element not found";
                }
            }
            catch (NoSuchElementException ex)
            {
                // Handle the case where the element is not found
                Console.WriteLine("Element not found: " + ex.Message);
                return "Message element not found";
            }
        }
    }
}
