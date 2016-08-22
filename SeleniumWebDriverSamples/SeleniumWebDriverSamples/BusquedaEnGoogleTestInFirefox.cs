using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriverSamples
{
    /// <summary>
    /// Summary description for BusquedaEnGoogleTestInFirefox
    /// </summary>
    [TestClass]
    public class BusquedaEnGoogleTestInFirefox
    {
        public BusquedaEnGoogleTestInFirefox()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

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
