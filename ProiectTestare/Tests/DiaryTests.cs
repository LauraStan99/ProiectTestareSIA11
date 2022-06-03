using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectTestare.PageObjects.Home;
using ProiectTestare.PageObjects.Login;
using ProiectTestare.PageObjects.Shared.MenuController;
using ProiectTestare.Tests.Shared;
using ProiectTestare.Utils;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class DiaryTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        private By TableActivityMonitoring =>
            By.XPath("/html/body/div[1]/div[4]/div[2]/div[1]/div/table/tbody/tr/td[2]/div/div[2]/table");

        IWebElement Table => _driver.FindElement(TableActivityMonitoring);


        [TestInitialize]
        public void TestSetup()
        {
            _driver = new ChromeDriver();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");

            var menu = new LoggedOutMenuController(_driver);
            _loginPage = menu.NavigateToLoginPage();
            _loginPage.LoginWith("laurastan1999@gmail.com", "Laura123456789");

            _homePage = new HomePage(_driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void AddNewFoodToDiarySuccessfully()
        {
            _homePage.AddFoodToDiary("500");

            // verify if a new food (row) has been added to the activity monitoring table
            _driver.WaitForElement(TableActivityMonitoring);
            int numberOfRowsInTable = Table.FindElements(By.TagName("tr")).Count;

            Assert.IsTrue(numberOfRowsInTable > 0);
        }

        [TestMethod]
        public void AddNewExerciseSuccessfully()
        {
            _homePage.AddEcerciseToDiary(ExercisesFactory.ValidExercise());

            // verify if a new food (row) has been added to the activity monitoring table
            _driver.WaitForElement(TableActivityMonitoring);
            int numberOfRowsInTable = Table.FindElements(By.TagName("tr")).Count;

            Assert.IsTrue(numberOfRowsInTable > 0);
        }

        [TestMethod]
        public void AddNewNoteSuccessfully()
        {
            _homePage.AddNoteToDiary("some text for note");

            // verify if a new food (row) has been added to the activity monitoring table
            _driver.WaitForElement(TableActivityMonitoring);
            int numberOfRowsInTable = Table.FindElements(By.TagName("tr")).Count;

            Assert.IsTrue(numberOfRowsInTable > 0);
        }
    }

}
