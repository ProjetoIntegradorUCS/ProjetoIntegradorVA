using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;
        
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver();

            baseURL = "https://www.google.com/";
        }
        
        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        
        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [TestMethod]
        public void VerificaMascara()
        {
            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[1]/following::li[2]")).Click();
        }

        [TestMethod]
        public void VerificaVentilacao()
        {
            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[2]/preceding::li[2]")).Click();
        }

        [TestMethod]
        public void VerificaDistanciamento()
        {
            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[2]/preceding::li[1]")).Click();
        }

        [TestMethod]
        public void VerificaLinksExternos()
        {
            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[2]/preceding::i[3]")).Click();

            var browserTabs = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);

            driver.Url.Equals("");

            driver.Close();
            driver.SwitchTo().Window(browserTabs[0]);

            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[2]/preceding::i[2]")).Click();

            var browserTabsTwo = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);

            driver.Close();
            driver.SwitchTo().Window(browserTabs[0]);

            driver.Navigate().GoToUrl("http://localhost:41787/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='covid care'])[2]/preceding::i[1]")).Click();

            var browserTabsThree = driver.WindowHandles;
            driver.SwitchTo().Window(browserTabs[1]);

            driver.Close();
            driver.SwitchTo().Window(browserTabs[0]);
        }

        [TestMethod]
        public void VerificarTamanhoTela()
        {
            driver.Manage().Window.Size = new System.Drawing.Size(480, 320);
            VerificaDistanciamento();
            VerificaVentilacao();
            VerificaMascara();
            VerificaLinksExternos();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
