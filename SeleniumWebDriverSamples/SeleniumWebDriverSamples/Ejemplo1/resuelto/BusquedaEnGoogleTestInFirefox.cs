using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo1.Resuelto
{
    [TestClass]
    public class BusquedaEnGoogleTestInFirefox
    {
        [TestMethod]
        [TestCategory("Ejemplo1")]
        public void Cuando_Busco_Selenium_WebDriver_Entonces_Devuelve_Resultados()
        {
            //Crear Instancia de WebDriver para Firefox (versión 1 simple, versión 2 si da problemas versión 1)
            //Versión 1
            IWebDriver webDriver = new FirefoxDriver();

            /* Versión 2
            FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\Firefox.exe");
            FirefoxProfile profile = new FirefoxProfile();
            IWebDriver webDriver = new FirefoxDriver(binary, profile);
            */

            //Navegar a la url http://www.google.com
            webDriver.Navigate().GoToUrl("http://www.google.com");

            //Seleccionar la caja de búsqueda
            IWebElement cajaDeBusqueda = webDriver.FindElement(By.Name("q"));

            //Escribir "Selenium WebDriver"
            cajaDeBusqueda.SendKeys("Selenium WebDriver");

            //Hacer la búsqueda
            cajaDeBusqueda.Submit();

            //Cerrar instancia de WebDriver
            webDriver.Close();
        }
    }
}
