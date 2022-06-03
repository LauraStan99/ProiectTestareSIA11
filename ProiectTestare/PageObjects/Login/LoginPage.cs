using System.Threading;
using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Login
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private static By Email => By.CssSelector("input[type='email']");
        private IWebElement TxtEmail => _driver.FindElement(Email);
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[type='password']"));
        private IWebElement BtnLogin => _driver.FindElement(By.Id("login-button"));
        public IWebElement ValidationErrorMessage => _driver.FindElement(By.XPath("//span[@id='email_error']"));


        public HomePage LoginWith(string email, string password)
        {

            _driver.WaitForElement(Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);

            BtnLogin.Click();
            Thread.Sleep(2000);
            return new HomePage(_driver);
        }
    }
}
