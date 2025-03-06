using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace TestClientes
{
    public class TestCliente:IDisposable
    {
        private readonly IWebDriver _driver;

        public TestCliente()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Fact]
        public void Create_ReturnCreateView()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Create");

            // Capturar y enviar los elementos del formulario
            _driver.FindElement(By.Name("Cedula")).SendKeys("1234567890");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Perez");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Nombres")).SendKeys("Juan");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("01/01/1990");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Mail")).SendKeys("juan.perez@example.com");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Telefono")).SendKeys("123456789");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Direccion")).SendKeys("Calle Falsa 123");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("EstadoBool")).Click();
            Thread.Sleep(2000);

            // Enviar el formulario
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);

            // Validar que se redirige a la vista de índice
            Assert.Equal("https://localhost:7159/Cliente", _driver.Url);
        }

        [Fact]
        public void Details_ReturnDetailsView()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente");
            Thread.Sleep(2000);
            // Validar que se redirige a la vista de índice
            Assert.Equal("https://localhost:7159/Cliente", _driver.Url);
        }

        [Fact]
        public void Edit_ReturnEditView()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Edit/3");
            // Capturar , borrar el contenido y enviar los elementos del formulario
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Apellidos")).Clear();
            _driver.FindElement(By.Name("Apellidos")).SendKeys("Gallegos");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Nombres")).Clear();
            _driver.FindElement(By.Name("Nombres")).SendKeys("Edgar");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("FechaNacimiento")).Clear();
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("01/01/2000");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Mail")).Clear();
            _driver.FindElement(By.Name("Mail")).SendKeys("edgar.gm@mail.com");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Direccion")).Clear();
            _driver.FindElement(By.Name("Direccion")).SendKeys(text: "Calle Falsa 123");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("EstadoBool")).Click();
            Thread.Sleep(2000);

            // Enviar el formulario
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);

            // Validar que se redirige a la vista de índice
            Assert.Equal("https://localhost:7159/Cliente", _driver.Url);

        }

        [Fact]
        public void Edit_ReturnEditEmtyView()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Edit/2");
            // Capturar , borrar el contenido y enviar los elementos del formulario
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("Cedula")).Clear();
            _driver.FindElement(By.Name("Cedula")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Apellidos")).Clear();
            _driver.FindElement(By.Name("Apellidos")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Nombres")).Clear();
            _driver.FindElement(By.Name("Nombres")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("FechaNacimiento")).Clear();
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Mail")).Clear();
            _driver.FindElement(By.Name("Mail")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Telefono")).Clear();
            _driver.FindElement(By.Name("Telefono")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("Direccion")).Clear();
            _driver.FindElement(By.Name("Direccion")).SendKeys("");
            Thread.Sleep(2000);
            _driver.FindElement(By.Name("EstadoBool")).Click();
            Thread.Sleep(2000);
            // Enviar el formulario
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(2000);
            // Validar mensajes de error de los campos vacíos
            Assert.Equal("The Cedula field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Cedula']")).Text);
            Assert.Equal("The Apellidos field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Apellidos']")).Text);
            Assert.Equal("The Nombres field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Nombres']")).Text);
            Assert.Equal("The Mail field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Mail']")).Text);
            Assert.Equal("The Telefono field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Telefono']")).Text);
            Assert.Equal("The Direccion field is required.", _driver.FindElement(By.CssSelector("span[data-valmsg-for='Direccion']")).Text);

            Console.WriteLine("Prueba exitosa");
        }

        [Fact]
        public void Delete_ReturnIndexView()
        {
            _driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Delete/12");
            // Enviar el formulario
            _driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            Thread.Sleep(2000);
            // Validar que se redirige a la vista de índice
            Assert.Equal("https://localhost:7159/Cliente", _driver.Url);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
