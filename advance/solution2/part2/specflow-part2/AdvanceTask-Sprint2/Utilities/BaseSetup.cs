using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;
using System.IO;

namespace AdvanceTask_Sprint2.Utilities
{
    public class BaseSetup
    {
        public static IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;

        [OneTimeSetUp]
        public void ExtentReportsSetup()
        {

            try
            {
                extent = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\ExtentReport\\");
                extent.AttachReporter(htmlReporter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up ExtentReports: {ex.Message}");
            }
        }

        [SetUp]
        public void SetupActions()
        {
            Console.WriteLine("Setting up WebDriver...");
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            Console.WriteLine($"Executing scenario: {scenarioTitle}");
            test = extent.CreateTest(scenarioTitle);
        }

        [TearDown]
        public void TearDownActions()
        {         
                test.Log(Status.Pass, "Test Passed");
                Close();
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
            string fullPath = Path.Combine("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\", screenshotPath); // Adjust the path
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}