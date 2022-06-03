using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProiectTestare.PageObjects.Register.InputData;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Settings
{
    public class SettingsPage
    {
        private readonly IWebDriver _driver;
        private static By ProfileAndTargetOption => By.XPath("/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[1]/td/table/tbody/tr/td[3]");
        private static By ErrorMessage => By.CssSelector("div[class='validation-error-container']");

        private static By UpdateWeightAction =>
            By.XPath(
                "//*[@id='cronometerApp']/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[3]/div[1]/div[2]/div[3]/button");

        private static By UpdateBodyFatIcon => By.CssSelector("img[src='https://cdn1.cronometer.com/img/metric/body-fat.png']");
        private static By WeightInput => By.CssSelector("input[max='99999']");
        private static By BodyFatInput => By.CssSelector("input[max='100']");
        private static By UnitInput => By.CssSelector("select[style='width: 200px;']");
        private static By AddNewWeight => By.CssSelector("button[class='gwt-SubmitButton btn-green-flat'");
        private static By BirthdayDay =>
            By.XPath(
                "/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[2]/div[1]/div[2]/div[1]/span[1]/select");

        private IWebElement BtnProfileAndTargetOption => _driver.FindElement(ProfileAndTargetOption);
        private IWebElement DdlBirthdayDay => _driver.FindElement(BirthdayDay);
        private IWebElement DdlBirthdayMonth => _driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[2]/div[1]/div[2]/div[1]/span[2]/select"));
        private IWebElement TxtBirthdayYear => _driver.FindElement(By.XPath("/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[2]/div[1]/div[2]/div[1]/input"));
        private IWebElement ValidationErrorMessage => _driver.FindElement(ErrorMessage);
        private IWebElement BtnUpdateWeight => _driver.FindElement(UpdateWeightAction);
        private IWebElement BtnUpdateBodyFatOption => _driver.FindElement(UpdateBodyFatIcon);
        private IWebElement TxtWeight => _driver.FindElement(WeightInput);
        private IWebElement TxtBodyFat => _driver.FindElement(BodyFatInput);
        private IWebElement DdlUnit => _driver.FindElement(UnitInput);
        private IWebElement BtnSaveChanges => _driver.FindElement(AddNewWeight);

        private By UpdatedWeightTxt => By.XPath("/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[3]/div[1]/div[2]/div[1]/div");
        private IWebElement TxtUpdatedWeightValue =>
            _driver.FindElement(UpdatedWeightTxt);
        public string CurrentWeightValue
        {
            get
            {
                _driver.WaitForElement(UpdatedWeightTxt, 30);
                return TxtUpdatedWeightValue.Text;
            }
        }

        private By UpdatedBodyFatTxt => By.XPath("/html/body/div[1]/div[4]/div[2]/div[4]/div/div/table/tbody/tr[2]/td/div/div[2]/div/div[1]/div/div[2]/div[2]/div[2]/div[2]/div[1]/div");
        private IWebElement TxtUpdatedBodyFatValue =>
            _driver.FindElement(UpdatedBodyFatTxt);
        public string CurrentBodyFat
        {
            get
            {
                _driver.WaitForElement(UpdatedBodyFatTxt, 30);
                return TxtUpdatedBodyFatValue.Text;
            }
        }


        public string NewDayText
        {
            get
            {
                _driver.WaitForElement(BirthdayDay, 30);
                SelectElement select = new SelectElement(DdlBirthdayDay);
                return select.SelectedOption.Text;
            }
            
        }

        public string InvalidDataErrorMessage
        {
            get
            {
                _driver.WaitForElement(ErrorMessage, 30);
                return ValidationErrorMessage.Text;

            }

        }

        public SettingsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void UpdateBirthdayInProfile(string newDay , string newMonth, string newYear )
        {
            _driver.WaitForElement(ProfileAndTargetOption);
            BtnProfileAndTargetOption.Click();

            var dayOfBirtday = new SelectElement(DdlBirthdayDay);
            dayOfBirtday.SelectByText(newDay);

            var monthOfBirtday = new SelectElement(DdlBirthdayMonth);
            monthOfBirtday.SelectByText(newMonth);

            TxtBirthdayYear.Click();
            TxtBirthdayYear.Clear();
            TxtBirthdayYear.SendKeys(newYear);
            TxtBirthdayYear.SendKeys(Keys.Enter);
        }

        public void UpdateCurrentWeightInProfile(string newWeight, int unit)
        {

            _driver.WaitForElement(ProfileAndTargetOption);
            BtnProfileAndTargetOption.Click();

            _driver.WaitForElement(UpdateWeightAction);
            BtnUpdateWeight.Click();

            _driver.WaitForElement(WeightInput);
            TxtWeight.SendKeys(newWeight);

            var selectedUnit = new SelectElement(DdlUnit);
            selectedUnit.SelectByIndex(unit);

            _driver.WaitForElement(AddNewWeight);
            BtnSaveChanges.Click();
        }

        public void UpdateBodyFatInProfile(string newBodyFat, int unit)
        {

            _driver.WaitForElement(ProfileAndTargetOption);
            BtnProfileAndTargetOption.Click();

            _driver.WaitForElement(UpdateWeightAction);
            BtnUpdateWeight.Click();

            _driver.WaitForElement(UpdateBodyFatIcon);
            BtnUpdateBodyFatOption.Click();

            _driver.WaitForElement(BodyFatInput);
            TxtBodyFat.SendKeys(newBodyFat);

            var selectedUnit = new SelectElement(DdlUnit);
            selectedUnit.SelectByIndex(unit);

            _driver.WaitForElement(AddNewWeight);
            BtnSaveChanges.Click();
        }
    }
}
