using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;

namespace ReqnrollTesting.Utilities
{
    public static class WebDriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(string browser)
        {
            if (_driver == null)
            {
                Console.WriteLine("Creando una nueva instancia de WebDriver...");
                _driver = browser.ToLower() switch
                {
                    "chrome" => new OpenQA.Selenium.Chrome.ChromeDriver(),
                    "firefox" => new OpenQA.Selenium.Firefox.FirefoxDriver(),
                    "edge" => new OpenQA.Selenium.Edge.EdgeDriver(),
                    _ => throw new ArgumentException($"Browser '{browser}' is not supported")
                };
            }
            else
            {
                Console.WriteLine("Usando la instancia existente de WebDriver...");
            }

            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                Console.WriteLine("Cerrando WebDriver...");
                try
                {
                    _driver.Close(); // Cierra la ventana del navegador
                    _driver.Quit();  // Cierra el proceso del WebDriver
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cerrar WebDriver: " + ex.Message);
                }
                finally
                {
                    _driver.Dispose();
                    _driver = null;
                }
            }
        }

    }
}