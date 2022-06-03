using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProiectTestare.PageObjects.Register.InputData;
using ProiectTestare.PageObjects.Settings;
using ProiectTestare.PageObjects.Shared.MenuController;
using ProiectTestare.Tests.Shared;

namespace ProiectTestare.Tests
{
    [TestClass]
    public class SettingsTests
    {
        private IWebDriver _driver;
        private SettingsPage _settingsPage;


        [TestInitialize]
        public void StartUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://cronometer.com/");

            var menu = new LoggedOutMenuController(_driver);
            _settingsPage = menu.NavigateToSettingsPage();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UpdateBirthdayInProfileSettingsSuccessfully()
        {
            _settingsPage.UpdateBirthdayInProfile("28", MonthEnum.August.ToString(), "1999");

            var actualBirthdayDay = _settingsPage.NewDayText;

            Assert.AreEqual(AccountFactory.ValidAccount().BirthdayDay, actualBirthdayDay);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UpdateBirthdayInProfileSuccessfully()
        {
            _settingsPage.UpdateBirthdayInProfile("27", MonthEnum.August.ToString(), "2050");

            Assert.AreEqual(Constants.InvalidYearErrorMessage, _settingsPage.InvalidDataErrorMessage);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UpdateCurrentWeightInProfileSuccessfully()
        {
            var newWeight = "60";
            _settingsPage.UpdateCurrentWeightInProfile(newWeight, 1);

            Assert.AreEqual($"{newWeight}.0", _settingsPage.CurrentWeightValue);
        }

        [TestMethod]
        [TestCategory("Smoke")]
        public void UpdateBodyFatInProfileSuccessfully()
        {
            var newBodyFat = "20";
            _settingsPage.UpdateBodyFatInProfile(newBodyFat, 1);

            Assert.AreEqual($"{newBodyFat}.0%", _settingsPage.CurrentBodyFat);
        }
    }
}
