using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo2.Resuelto
{
    [TestClass]
    public class BusquedaEnGoogleTestInFirefox
    {
        [TestMethod]
        [TestCategory("Ejemplo2")]
        public void Cuando_Busco_Selenium_WebDriver_Entonces_El_Primer_Resultado_Es_La_Pagina_De_Selenium()
        {
            //Crear Instancia de WebDriver para Firefox
            FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\Firefox.exe");
            FirefoxProfile profile = new FirefoxProfile();
            IWebDriver webDriver = new FirefoxDriver(binary, profile);
            //IWebDriver webDriver = new FirefoxDriver();
            //webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            //webDriver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));

            //Navegar a la url http://www.google.com
            webDriver.Navigate().GoToUrl("http://www.google.com");

            //Seleccionar la caja de búsqueda
            IWebElement cajaDeBusqueda = webDriver.FindElement(By.Name("q"));

            //Escribir "Selenium WebDriver"
            cajaDeBusqueda.SendKeys("Selenium WebDriver");

            //Hacer la búsqueda
            cajaDeBusqueda.Submit();

            //Wait para esperar a que se carguen los resultado Ajax (podemos hacelo explicito: sleep o implícito: wait)
            //System.Threading.Thread.Sleep(10000);
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a")));

            //Seleccionamos el primer elemento de los resultados
            IWebElement firstResult = webDriver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a"));

            //Comprobamos si la Url es la que esperamos. (2 versiones)

            //Versión 1: Ejemplo en el que solo comprobamos el data-href del link de google
            
            string urlActual = firstResult.GetAttribute("href");

            //Versión 2: Ejemplo en el que solo comprobamos la url. 
            //Lo clickamos
            /*
            firstResult.Click();

            //Tenemos que poner un sleep para esperar la redirección de Google poruqe el click va a una página intermedia.
            System.Threading.Thread.Sleep(500);

            string urlActual = webDriver.Url;
            */

            try
            {
                Assert.AreEqual("http://www.seleniumhq.org/projects/webdriver/", urlActual);
            }
            finally
            {
                //Cerrar instancia de WebDriver
                webDriver.Close();
            }
        }
    }
}
