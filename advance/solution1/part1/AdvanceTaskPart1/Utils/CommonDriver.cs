using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AdvanceTaskPart1.Pages.Components.ProfilePage;
using AdvanceTaskPart1.Steps;

namespace AdvanceTaskPart1.Utils
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static LoginSteps loginStepsObj;
        public static HomePageSteps homePageStepsObj;
        public static ProfileMenuTab profileTabsObj;

        [OneTimeSetUp]
        public void ExtentReportSetup()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                var htmlReporter = new ExtentHtmlReporter("C:\\GitProjects\\MarsAdvancedTaskPart1\\AdvanceTaskPart1\\Reports\\");
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [SetUp]
        public void BrowserSetup()
        {

            string baseURL = "http://localhost:5000/";
            driver.Navigate().GoToUrl(baseURL);
            loginStepsObj = new LoginSteps();
            homePageStepsObj = new HomePageSteps();
            loginStepsObj.doLogin();
            homePageStepsObj.VerifyLogin();
            CleanUp();
            var testName = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testName);
        }
        private static void CleanUp()
        {
            profileTabsObj = new ProfileMenuTab();
            profileTabsObj.ClearSkillData();
            profileTabsObj.ClearLangData();
        }
        [TearDown]
        public void CloseTestrun()
        {
            driver.Quit();
        }
        [OneTimeTearDown]
        public void TeardownReport()
        {
            extent.Flush();
        }
    }
}
