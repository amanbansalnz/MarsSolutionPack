using AdvanceTask_Sprint2.Components.ProfilePageTabComponents;
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
    public class AssertionLanguage : BaseSetup
    {
        AddUpdateDeleteLanguageComponent addUpdateDeleteLanguageComponentObj;
        public AssertionLanguage()
        {
            addUpdateDeleteLanguageComponentObj = new AddUpdateDeleteLanguageComponent();
        }
        public void assertDeleteLanguage()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            int rowCount = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table//tbody")).Count;
            Assert.That(rowCount == 0, "Records Not Deleted Successfully");
            Thread.Sleep(2000);
        }

        public void AddLanguageAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }

        public void UpdatedLanguageAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
        public void DeletedLanguageAssertion(string expected, string actual)
        {
            Assert.IsTrue(actual.Contains(expected), $"Expected message: '{expected}' was not found in the actual message: '{actual}'");
        }
    }

}




