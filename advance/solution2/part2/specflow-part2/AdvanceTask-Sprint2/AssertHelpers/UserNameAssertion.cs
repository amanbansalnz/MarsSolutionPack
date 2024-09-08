using AdvanceTask_Sprint2.TestModel;
using AdvanceTask_Sprint2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTask_Sprint2.AssertHelpers
{
    public  class UserNameAssertion : BaseSetup
    {
        public void AvailabilityAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void HoursAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void EarnTargetAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void AssertFirstName(UserNameModel username)
        {
            IWebElement FirstName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            string actualFirstName = FirstName.Text.Trim();
            List<UserNameModel> UserNameModelList = JsonHelper.ReadTestDataFromJson<UserNameModel>("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\JsonDataFiles\\UserFirstLastName.json");         
            string expectedName = "Hi " + username.firstName.Trim();  // Trim to remove leading/trailing whitespaces
            Assert.That(actualFirstName, Is.EqualTo(expectedName));
        }
    }
}
