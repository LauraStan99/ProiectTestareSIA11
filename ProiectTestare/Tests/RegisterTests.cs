using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectTestare.PageObjects.Login;
using ProiectTestare.PageObjects.Register;
using ProiectTestare.Tests.Shared;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class RegisterTests
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;

        public RegisterTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");
            _driver.FindElement(by: By.XPath("//*[@id='hero']/div/div/div[1]/div/a")).Click();
            Thread.Sleep(2000);
            _registerPage = new RegisterPage(_driver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotRegisterSuccessfullyWhenPasswordsDoNotMatch()
        {
            _registerPage.RegisterWith(AccountFactory.InvalidAccount());
            //Assert
            Assert.AreEqual(Constants.RegisterFailedErrorMessage, _registerPage.ValidationErrorMessage.Text);
        }
    }
}
