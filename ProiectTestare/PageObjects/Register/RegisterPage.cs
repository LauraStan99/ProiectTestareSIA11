using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProiectTestare.PageObjects.Register.InputData;

namespace ProiectTestare.PageObjects.Register
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private IWebElement TxtEmail => _driver.FindElement(By.Id("emailInput"));
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[placeholder='Password']"));
        private IWebElement TxtRepeatPassword => _driver.FindElement(By.CssSelector("input[placeholder='Confirm Password']"));
        private IWebElement DdlBirthdayDay => _driver.FindElement(By.Id("day"));
        private IWebElement DdlBirthdayMonth => _driver.FindElement(By.Id("monthselect"));
        private IWebElement TxtBirthdayYear => _driver.FindElement(By.Id("year"));
        private IWebElement BtnAgreeTermsAndPolicy => _driver.FindElement(By.XPath("/html/body/div/div[3]/div/form/div/div[3]/div/div[1]/label"));
        private IWebElement BtnCreateAccount => _driver.FindElement(By.Id("createaccount"));
        public IWebElement ValidationErrorMessage => _driver.FindElement(By.XPath("/html/body/div[2]/div[2]/form/div[1]"));

        public RegisterPage(IWebDriver browser)
        {
            _driver = browser;
        }

        public void RegisterWith(NewAccountBo accountDetails)
        {
            TxtEmail.SendKeys(accountDetails.Email);
            TxtPassword.SendKeys(accountDetails.Password);
            TxtRepeatPassword.SendKeys(accountDetails.ConfirmPassword);

            var dayOfBirtday = new SelectElement(DdlBirthdayDay);
            dayOfBirtday.SelectByText(accountDetails.BirthdayDay);

            var monthOfBirtday = new SelectElement(DdlBirthdayMonth);
            monthOfBirtday.SelectByText(accountDetails.BirthdayMonth.ToString());

            TxtBirthdayYear.Clear();
            TxtBirthdayYear.SendKeys(accountDetails.BirthdayYear);

            BtnAgreeTermsAndPolicy.Click();

            BtnCreateAccount.Click();
        }
    }
}
