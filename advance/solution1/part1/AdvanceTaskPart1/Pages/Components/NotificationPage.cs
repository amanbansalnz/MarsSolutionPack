using AdvanceTaskPart1.Utils;
using OpenQA.Selenium;

namespace AdvanceTaskPart1.Pages.Components
{
    public class NotificationPage : CommonDriver
    {
        private static IWebElement showMore;
        private static IWebElement selectAll;
        private static IWebElement unSelectAll;
        private static IWebElement showLess;
        private static IWebElement markAsRead;
        private static IWebElement deleteIcon;
        private static IWebElement selectCheckBoxIcon;
        public bool CheckSelectAllNotification()
        {
            renderSelectNotification();
            selectAll.Click();
            return true;
        }
        public bool CheckUnSelectAllNotification()
        {
            Thread.Sleep(2000);
            renderSelectNotification();
            selectAll.Click();
            renderUnselectNotification();
            Thread.Sleep(2000);
            unSelectAll.Click();
            return true;
        }
        public void DeleteNotification()
        {
            Thread.Sleep(2000);
            renderSelectCheckBox();
            selectCheckBoxIcon.Click();
            renderReadDeleteNotification();
            deleteIcon.Click();
            Thread.Sleep(3000);
        }
        public bool CheckLoadMoreNotification()
        {
            Thread.Sleep(2000);
            renderMoreNotification();
            showMore.Click();
            return true;
        }
        public bool CheckShowLessNotification()
        {
            Thread.Sleep(2000);
            renderSelectNotification();
            selectAll.Click();
            Thread.Sleep(2000);
            renderMoreNotification();
            showMore.Click();
            Thread.Sleep(2000);
            renderLessNotification();
            showLess.Click();
            return true;
        }
        public void MarkAsReadNotification()
        {
            Thread.Sleep(2000);
            renderSelectNotification();
            selectAll.Click();
            Thread.Sleep(2000);
            renderReadDeleteNotification();
            markAsRead.Click();
        }
        public void renderMoreNotification()
        {
            try
            {
                showMore = driver.FindElement(By.XPath("//a[contains(text(),'Load More')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLessNotification()
        {
            try
            {
                showLess = driver.FindElement(By.XPath("//a[@class='ui button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void renderSelectNotification()
        {
            try
            {
                selectAll = driver.FindElement(By.XPath(" //i[@class='mouse pointer icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderUnselectNotification()
        {
            try
            {
                unSelectAll = driver.FindElement(By.XPath("//div[@data-tooltip='Unselect all']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSelectCheckBox()
        {
            selectCheckBoxIcon = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));
        }
        public void renderReadDeleteNotification()
        {
            markAsRead = driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]/i"));
            deleteIcon = driver.FindElement(By.XPath("//i[@class='trash icon']"));
        }
    }
}
