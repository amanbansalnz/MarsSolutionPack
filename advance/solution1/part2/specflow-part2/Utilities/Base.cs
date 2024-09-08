using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowAutomation.Utilities
{
    public class Base
    {
#pragma warning disable
        public static IWebDriver driver;
        private static ExtentReports extent;
        private static ExtentTest testreport;

        [SetUp]
        public void SetupAuction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
        }
        public void LogScreenshot(string ScreenshotName)
        {
            string screenshotPath = CaptureScreenshot(ScreenshotName);
            if (testreport != null)
            {
                testreport.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }

        public static string CaptureScreenshot(string screenshotName)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine("ScreenshotReport", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
            string fullPath = Path.Combine("D:\\IC Course\\AdvanceSpecflow\\Mars-AdvanceSpecflow\\SpecflowAutomation", screenshotPath);
#pragma warning disable
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);

            return fullPath;
        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
        }
    }
}