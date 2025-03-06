using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using static OpenQA.Selenium.BiDi.Modules.Script.RealmInfo;

namespace TestClientes
{
    public class UnitTest1
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public UnitTest1()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));

        }

        public bool EsMailReValido(string email)
        {
            return Regex.IsMatch(email, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
        }

        [Theory]
        [InlineData("usuario@gmail.com", true)]
        [InlineData("test@empresa.com", true)]
        [InlineData("correo@_prueba.com", false)]
        [InlineData("sin_arrobacom", false)]
        [InlineData("sin_punto@com", false)]
        [InlineData("sin_punto@com.", false)]
        [InlineData("sin_punto@com.c", false)]
        public void ValidarEmial(string email, bool resultadoEsperado)
        {
            bool resultado = EsMailReValido(email);
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void Test_NavegadorGoogle()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.bing.com");

                var buscarText = _wait.Until(d => d.FindElement(By.Name("q")));

                Thread.Sleep(3000);

                buscarText.SendKeys("Selenium");

                Thread.Sleep(2000);

                buscarText.SendKeys(Keys.Enter);

                Thread.Sleep(2000);

                var resultados = _wait.Until(d => d.FindElements(By.CssSelector("h2")));

                Assert.True(resultados.Count > 0, "No se encontraron resultados de la busqueda");

                // Adicion que no corresponde a la prueba
                // abrir consola y mostrar resultados


                Console.WriteLine("Prueba exitosa");
                Console.WriteLine("Resultados encontrados: " + resultados.Count);
                Console.WriteLine("10 segundos para cerrar el navegador");
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            finally
            {
                _driver.Quit();
            }
        }
    }
}