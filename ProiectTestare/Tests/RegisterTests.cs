using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectTestare.PageObjects.Register;
using ProiectTestare.PageObjects.Shared.MenuController;
using ProiectTestare.Tests.Shared;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class RegisterTests
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;
        private Random rand;


        [TestInitialize]
        public void StartUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");

            var menu = new LoggedOutMenuController(_driver);
            _registerPage = menu.NavigateToRegisterPage();
            rand = new Random();
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

            Assert.AreEqual(Constants.RegisterFailedErrorMessage, _registerPage.ValidationErrorMessage.Text);
        }


        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldRegisterSuccessfully()
        {
            var validAccount = AccountFactory.ValidAccount();
            validAccount.Email=  $"{rand.Next(1000, 1500)}@gmail.com";
            _registerPage.RegisterWith(validAccount);

            Assert.AreEqual(Constants.ConfirmationEmailMessage, _registerPage.ConfirmationEmailText);
        }
    }
}
