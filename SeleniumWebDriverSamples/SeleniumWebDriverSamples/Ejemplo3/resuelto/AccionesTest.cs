using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples.Ejemplo3.Resuelto
{
    [TestClass]
    public class AccionesTest
    {
        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_SendKeys()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_Select_CheckBox_Option()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_Select_DropDown_Option()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_Click_Link()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_Click_Button()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        [TestCategory("Ejemplo3")]
        public void Accion_Click_En_Filtro_Pisos_M()
        {
            FirefoxBinary binary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\Firefox.exe");
            FirefoxProfile profile = new FirefoxProfile();
            profile.AcceptUntrustedCertificates = true;
            IWebDriver webDriver = new FirefoxDriver(binary, profile);

            webDriver.Navigate().GoToUrl("http://m.habitaclia.com/comprar-vivienda-en-barcelona/provincia_barcelona-barcelones-area_6/m_filtros.htm");

            //Click Javascript por ejemplo para elementos ocultos:
            IWebElement theHiddenElem = webDriver.FindElement(By.Id("Piso"));
            String js = "arguments[0].click();";
            ((IJavaScriptExecutor)webDriver).ExecuteScript(js, theHiddenElem);
        }
    }
}

