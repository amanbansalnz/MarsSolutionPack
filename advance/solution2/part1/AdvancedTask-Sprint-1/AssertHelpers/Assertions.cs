using Advanced_Task_1.TestModel;
using Advanced_Task_1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Task_1.AssertHelpers
{
    public class Assertions : BaseSetup
    {
        public void getUserName()
        {
            IWebElement UserName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            Assert.AreEqual("Hi Murugeshwari", UserName.Text, "Hi Murugeshwari logged in successfully");
        }
        public void AssertFirstName(UserNameModel username)
        {
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            string actualFirstName = FirstName.Text;
            List<UserNameModel> UserNameModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\JsonDataFiles\\UserfirstLastName.json");
            string expectedName = "Hi " + username.firstName;
            Assert.That(actualFirstName, Is.EqualTo(expectedName));
        }

    }
    }

