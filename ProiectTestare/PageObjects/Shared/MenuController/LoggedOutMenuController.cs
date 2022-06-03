using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home;
using ProiectTestare.PageObjects.Login;
using ProiectTestare.PageObjects.Register;
using ProiectTestare.PageObjects.Settings;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Shared.MenuController
{
    public class LoggedOutMenuController : MenuControllerCommon
    {
        public LoggedOutMenuController(IWebDriver driver) : base(driver)
        {
        }

        private By SignIn => By.XPath("/html/body/div[1]/div[1]/div[1]/div[2]/div");
        private IWebElement BtnSignIn => _driver.FindElement(SignIn);

        private By SignUp => By.XPath("//*[@id='hero']/div/div/div[1]/div/a");
        private IWebElement BtnSignUp => _driver.FindElement(SignUp);

        public LoginPage NavigateToLoginPage()
        {
            _driver.WaitForElement(SignIn);

            BtnSignIn.Click();

            return new LoginPage(_driver);
        }

        public RegisterPage NavigateToRegisterPage()
        {
            _driver.WaitForElement(SignUp);

            BtnSignUp.Click();

            return new RegisterPage(_driver);
        }

        public SettingsPage NavigateToSettingsPage()
        {
            _driver.WaitForElement(SignIn);

            BtnSignIn.Click();

            var login =  new LoginPage(_driver);
            login.LoginWith("laurastan1999@gmail.com", "Laura123456789");

            var home = new HomePage(_driver);
            return home.NavigateToSettingsPage();
        }
    }
}
