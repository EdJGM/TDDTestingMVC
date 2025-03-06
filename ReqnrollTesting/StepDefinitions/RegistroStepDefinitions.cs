using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTesting.Utilities;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class RegistroStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public RegistroStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("El usuario esta en la pagina de login")]
        public void GivenElUsuarioEstaEnLaPaginaDeLogin()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la pagina del login");
        }

        [When("Ingresa las credenciales correo {string} y la contraseña{string}")]
        public void WhenIngresaLasCredencialesCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.CssSelector("input[data-qa='signup-email']")).SendKeys(email);
            _driver.FindElement(By.CssSelector("input[data-qa='signup-name']")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario ingresa correo: {email} y contraseña: {password}");
        }

        [When("Hace clic en el boton de Signup")]
        public void WhenHaceClicEnElBotonDeSignup()
        {
            _driver.FindElement(By.CssSelector("button[data-qa='signup-button']")).Click();
            _test.Log(Status.Info, "El usuario hace clic en el boton de Signup");
        }

        [Then("El usuario debe ser redirigido a la pagina de registro")]
        public void ThenElUsuarioDebeSerRedirigidoALaPaginaDeRegistro()
        {
            var currentUrl = _driver.Url;
            if (currentUrl.Contains("signup"))
            {
                _test.Log(Status.Pass, "El usuario fue redirigido a la pagina de registro");
            }
            else
            {
                _test.Log(Status.Fail, "El usuario no fue redirigido a la pagina de registro");
            }
        }

        [Given("El usuario esta en la pagina de registro")]
        public void GivenElUsuarioEstaEnLaPaginaDeRegistro()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/signup");
            _test.Log(Status.Pass, "Usuario navega a la pagina de registro");
        }

        [When("Ingresa los datos solicitados")]
        public void WhenIngresaLosDatosSolicitados(Table dataTable)
        {
            var data = dataTable.Rows[0];
            _driver.FindElement(By.CssSelector("input[data-qa='name']")).SendKeys(data["Name"]);
            _driver.FindElement(By.CssSelector("input[data-qa='email']")).SendKeys(data["Email"]);
            _driver.FindElement(By.CssSelector("input[data-qa='password']")).SendKeys(data["Password"]);
            _driver.FindElement(By.CssSelector("select[data-qa='days']")).SendKeys(data["DateOfBirth"].Split('/')[0]);
            _driver.FindElement(By.CssSelector("select[data-qa='months']")).SendKeys(data["DateOfBirth"].Split('/')[1]);
            _driver.FindElement(By.CssSelector("select[data-qa='years']")).SendKeys(data["DateOfBirth"].Split('/')[2]);
            if (data["Newsletter"] == "true")
            {
                _driver.FindElement(By.CssSelector("input[data-qa='newsletter']")).Click();
            }
            if (data["Optin"] == "true")
            {
                _driver.FindElement(By.CssSelector("input[data-qa='optin']")).Click();
            }
            _driver.FindElement(By.CssSelector("input[data-qa='first_name']")).SendKeys(data["FirstName"]);
            _driver.FindElement(By.CssSelector("input[data-qa='last_name']")).SendKeys(data["LastName"]);
            _driver.FindElement(By.CssSelector("input[data-qa='company']")).SendKeys(data["Company"]);
            _driver.FindElement(By.CssSelector("input[data-qa='address']")).SendKeys(data["Address1"]);
            _driver.FindElement(By.CssSelector("input[data-qa='address2']")).SendKeys(data["Address2"]);
            _driver.FindElement(By.CssSelector("select[data-qa='country']")).SendKeys(data["Country"]);
            _driver.FindElement(By.CssSelector("input[data-qa='state']")).SendKeys(data["State"]);
            _driver.FindElement(By.CssSelector("input[data-qa='city']")).SendKeys(data["City"]);
            _driver.FindElement(By.CssSelector("input[data-qa='zipcode']")).SendKeys(data["Zipcode"]);
            _driver.FindElement(By.CssSelector("input[data-qa='mobile_number']")).SendKeys(data["MobileNumber"]);
            _test.Log(Status.Info, "Usuario ingresa los datos solicitados");
        }


        [When("Hace clic en el boton de Create Account")]
        public void WhenHaceClicEnElBotonDeCreateAccount()
        {
            _driver.FindElement(By.CssSelector("button[data-qa='create-account']")).Click();
            _test.Log(Status.Info, "El usuario hace clic en el boton de Create Account");
        }

        [Then("El usuario debe ser redirigido a la pagina de bienvenida")]
        public void ThenElUsuarioDebeSerRedirigidoALaPaginaDeBienvenida()
        {
            var currentUrl = _driver.Url;
            if (currentUrl == "https://www.automationexercise.com/")
            {
                _test.Log(Status.Pass, "El usuario fue redirigido a la pagina de bienvenida");
            }
            else
            {
                _test.Log(Status.Fail, "El usuario no fue redirigido a la pagina de bienvenida");
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
