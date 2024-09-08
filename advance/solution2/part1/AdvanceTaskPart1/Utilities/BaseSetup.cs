using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using Advanced_Task_1.Pages;
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;


namespace Advanced_Task_1.Utilities
{
    public class BaseSetup
    {
        public static IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void ExtentReportsSetup()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\ExtentReport\\"); // Path to the report file
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void SetupActions()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDownActions()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                // Capture a screenshot if the test passes
                CaptureScreenshot(TestContext.CurrentContext.Test.Name + "_Pass");
            }
            test.Log(Status.Pass, "Test Passed");
            driver.Quit();
        }

        [OneTimeTearDown]
        public void ExtentReportsCleanup()
        {
            extent.Flush();
        }
        public void CaptureScreenshot(string screenshotName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = $"Screenshots/{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png"; // Remove "Screenshots" from the path
            string fullPath = Path.Combine("C:\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\AdvancedTask-Sprint-1\\", screenshotPath); // Adjust the path
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
        }


    }
}
