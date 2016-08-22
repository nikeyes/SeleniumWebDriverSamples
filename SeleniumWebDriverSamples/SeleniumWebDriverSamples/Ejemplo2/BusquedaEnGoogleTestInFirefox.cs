﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo2
{
    /// <summary>
    /// Summary description for BusquedaEnGoogleTestInFirefox
    /// </summary>
    [TestClass]
    public class BusquedaEnGoogleTestInFirefox
    {
        [TestMethod]
        public void Cuando_Busco_Selenium_WebDriver_Entonces_El_Primer_Resultado_Es_La_Pagina_De_Selenium()
        {
            string urlExpected = "http://www.seleniumhq.org/projects/webdriver/";
            string urlActual;

            IWebDriver webDriver = new FirefoxDriver();

            webDriver.Navigate().GoToUrl("http://www.google.com");

            IWebElement cajaDeBusqueda = webDriver.FindElement(By.Name("q"));

            cajaDeBusqueda.SendKeys("Selenium WebDriver");

            cajaDeBusqueda.Submit();

            System.Threading.Thread.Sleep(10000);

            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a")));

            IWebElement primerLink = webDriver.FindElement(By.CssSelector("#rso > div:nth-child(1) > div:nth-child(1) > div > h3 > a"));

            primerLink.Click();

            urlActual = webDriver.Url;

            Assert.AreEqual(urlExpected, urlActual);

            webDriver.Close();
        }
    }
}
