using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo1
{
    /// <summary>
    /// Summary description for BusquedaEnGoogleTestInFirefox
    /// </summary>
    [TestClass]
    public class Debug_BusquedaEnGoogleTestInFirefox
    {
        [TestMethod]
        public void Cuando_Busco_Selenium_WebDriver_Entonces_El_Primer_Resultado_Es_La_Pagina_De_Selenium()
        {
            IWebDriver webDriver = new FirefoxDriver();

            webDriver.Navigate().GoToUrl("http://www.google.com");

            IWebElement cajaDeBusqueda = webDriver.FindElement(By.Name("q"));

            cajaDeBusqueda.SendKeys("Selenium WebDriver");

            cajaDeBusqueda.Submit();

            IWebElement primerLink = webDriver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a"));

            primerLink.Click();

            Assert.AreEqual("http://www.seleniumhq.org/projects/webdriver/", webDriver.Url);

            webDriver.Close();
        }
    }
}
