using Reqnroll;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ReqnrollTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        // For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("Extentreport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _test = _extent.CreateTest(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;
            var isSuccess = scenarioContext.TestError == null;
            _test.Log(isSuccess ? Status.Pass : Status.Fail, isSuccess ? $"Paso exitoso: {stepInfo}" : $"Error: {stepInfo}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extent.Flush();
        }
    }
}
