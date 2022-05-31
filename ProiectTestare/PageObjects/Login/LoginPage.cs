using System.Threading;
using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home;

namespace ProiectTestare.PageObjects.Login
{
    internal class LoginPage
    {
        private readonly IWebDriver _driver;


        public LoginPage(IWebDriver browser)
        {
            _driver = browser;
        }

        private IWebElement TxtEmail => _driver.FindElement(By.CssSelector("input[type='email']"));
        private IWebElement TxtPassword => _driver.FindElement(By.CssSelector("input[type='password']"));
        private IWebElement BtnLogin => _driver.FindElement(By.Id("login-button"));
        public IWebElement ValidationErrorMessage => _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[2]/div[1]/div/span"));


        public HomePage LoginWith(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);

            BtnLogin.Click();
            Thread.Sleep(2000);
            return new HomePage(_driver);
        }
    }
}
