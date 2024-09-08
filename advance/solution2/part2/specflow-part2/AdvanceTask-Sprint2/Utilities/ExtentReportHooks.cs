using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

[Binding]
public sealed class ExtentReportHooks
{
    private static ExtentTest _feature;
    private static ExtentTest _scenario;
    private static ExtentReports _extent;

    [BeforeTestRun]
    public static void InitializeReport()
    {
        var htmlReporter = new ExtentHtmlReporter("C:\\AdvnacedTask-Sprint-2\\MVP-Advanced-Task-Sprint-2\\AdvanceTask-Sprint2\\AdvanceTask-Sprint2\\ExtentReport\\");
        _extent = new ExtentReports();
        _extent.AttachReporter(htmlReporter);
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }

    [BeforeScenario]
    public static void BeforeScenario(ScenarioContext scenarioContext)
    {
        _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
    }

    [AfterStep]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

        if (scenarioContext.TestError == null)
        {
            if (stepType == "Given")
                _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
            else if (stepType == "When")
                _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
            else if (stepType == "Then")
                _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
        }
        else
        {
            if (stepType == "Given")
                _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
            else if (stepType == "When")
                _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.InnerException);
            else if (stepType == "Then")
                _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)?.Fail(scenarioContext.TestError.Message);
        }
    }

    [AfterTestRun]
    public static void TearDownReport()
    {
        _extent.Flush();
    }
}
