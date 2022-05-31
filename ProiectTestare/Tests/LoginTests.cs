using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProiectTestare.PageObjects.Login;
using ProiectTestare.Tests.Shared;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;


        [TestInitialize]
        public void StartUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");
            _driver.FindElement(by: By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div")).Click();
            Thread.Sleep(2000);
            _loginPage = new LoginPage(_driver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldLoginSuccessfully()
        {
            _loginPage.LoginWith("laurastan1999@gmail.com", "Laura123456789");

            IWebElement logoElement = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div[1]"));
            IWebElement accountDetails = _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div[2]/div/div/ul/li[1]/div/div[1]/div"));

            Actions action = new Actions(_driver);
            //hover on logo element to render the child element that contains the details about the logged in user
            action.MoveToElement(logoElement).Perform();
            action.MoveToElement(accountDetails).Perform();
            action.Click().Build().Perform();

            Assert.AreEqual("laurastan1999@gmail.com", accountDetails.Text);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UserShouldNotLoginSuccessfullyWhenPasswordIsInvalid()
        {
            _loginPage.LoginWith("laurastan1999@gmail.com", "Laura");

            //Assert
            Assert.AreEqual(Constants.LoginFailedErrorMessage, _loginPage.ValidationErrorMessage.Text);
        }
    }
}
