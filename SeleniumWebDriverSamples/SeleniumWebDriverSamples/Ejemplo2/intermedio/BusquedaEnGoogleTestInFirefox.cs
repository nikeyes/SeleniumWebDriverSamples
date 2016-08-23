using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo2.Intermedio
{
    [TestClass]
    public class BusquedaEnGoogleTestInFirefox
    {
        [TestMethod]
        [TestCategory("Ejemplo2")]
        public void Cuando_Busco_Selenium_WebDriver_Entonces_El_Primer_Resultado_Es_La_Pagina_De_Selenium()
        {
            //Crear Instancia de WebDriver para Firefox
            IWebDriver webDriver = new FirefoxDriver();

            //Navegar a la url http://www.google.com
            webDriver.Navigate().GoToUrl("http://www.google.com");

            //Seleccionar la caja de búsqueda
            IWebElement cajaDeBusqueda = webDriver.FindElement(By.Name("q"));

            //Escribir "Selenium WebDriver"
            cajaDeBusqueda.SendKeys("Selenium WebDriver");

            //Hacer la búsqueda
            cajaDeBusqueda.Submit();

            //Seleccionamos el primer elemento de los resultados
            IWebElement firstResult = webDriver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a"));

            //Lo clickamos
            firstResult.Click();

            try
            {
                Assert.AreEqual("http://www.seleniumhq.org/projects/webdriver/", webDriver.Url);
            }
            finally
            {
                //Cerrar instancia de WebDriver
                webDriver.Close();
            }
        }
    }
}
