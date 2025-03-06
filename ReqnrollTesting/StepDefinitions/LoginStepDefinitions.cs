using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTesting.Utilities;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("Extentreport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("El usuario esta en la pagina del login")]
        public void GivenElUsuarioEstaEnLaPaginaDelLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la pagina del login");
        }

        [When("Ingresa las credenciales correo {string} y la contraseña {string}")]
        public void WhenIngresaLasCredencialesCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario ingresa correo: {email} y contraseña: {password}");
        }

        [When("Hace clic en el boton de Login")]
        public void WhenHaceClicEnElBotonDeLogin()
        {
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            _test.Log(Status.Info, "El usuario hace clic en el boton de Login");
        }

        [Then("Mostrar un mensaje de error")]
        public void ThenMostrarUnMensajeDeError()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.ClassName("login-error")) != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostro el mensaje de error esperado");

            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
