using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Shared.MenuController
{
    public class LoggedInMenuController : MenuControllerCommon
    {
        public LoggedInMenuController(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement BtnSignOut => _driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[1]/div[2]/div/div/ul/li[1]/div/div[2]/button"));

        private IWebElement LblCurrentUser => _driver.FindElement(By.XPath("//span[@data-test='current-user']"));

        //public AddressesOverviewPage NavigateToAddressesOverview()
        //{
        //    _driver.WaitForElement(Addresses);

        //    BtnAddresses.Click();

        //    return new AddressesOverviewPage(_driver);
        //}



        public string CurrentUser => LblCurrentUser.Text;
    }
}
