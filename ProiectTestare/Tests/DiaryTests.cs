using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProiectTestare.PageObjects.Home;
using ProiectTestare.PageObjects.Login;
using ProiectTestare.Tests.Shared;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class DiaryTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;


        [TestInitialize]
        public void TestSetup()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");

            _driver.FindElement(by: By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div")).Click();

            Thread.Sleep(2000);
            _loginPage = new LoginPage(_driver);
            _loginPage.LoginWith("laurastan1999@gmail.com", "Laura123456789");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void AddNewFoodToDiarySuccessfully()
        {
            Thread.Sleep(3000);
            _homePage = new HomePage(_driver);
            _homePage.AddFoodToDiary("500", "g");

            // verify if a new food (row) has been added to the table
            IWebElement table =
                _driver.FindElement(
                    By.XPath("/html/body/div[1]/div[4]/div[2]/div[1]/div/table/tbody/tr/td[2]/div/div[2]/table"));
            int numberOfRowsInTable = table.FindElements(By.TagName("tr")).Count;

            Assert.IsTrue(numberOfRowsInTable > 0);
        }

        [TestMethod]
        public void AddNewExerciseSuccessfully()
        {
            Thread.Sleep(3000);
            _homePage = new HomePage(_driver);
            _homePage.AddEcerciseToDiary(ExercisesFactory.ValidExercise());

            IWebElement table =
                _driver.FindElement(
                    By.XPath("/html/body/div[1]/div[4]/div[2]/div[1]/div/table/tbody/tr/td[2]/div/div[2]/table"));
            int numberOfRowsInTable = table.FindElements(By.TagName("tr")).Count;

            Assert.IsTrue(numberOfRowsInTable > 0);
        }
    }

}
