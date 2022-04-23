using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Testes
{
    [TestClass]
    public class Testes
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private EdgeDriver _driver;

        [TestInitialize]
        public void IniciaTestes()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver(options);

            VerificarTituloPagina();
            Limpar();
        }

        [TestMethod]
        public void VerificarTituloPagina()
        {
            // Replace with your own test logic
            _driver.Url = "https://localhost:44344/";
            Assert.AreEqual("COVID CARE", _driver.Title);
        }

        [TestCleanup]
        public void Limpar()
        {
            _driver.Quit();
        }
    }
}
