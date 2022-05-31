using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace ProiectTestare.PageObjects.Home.DialogPagesObjects
{
    internal class AddFoodDialog
    {
        private IWebDriver _driver;
        private IWebElement TdOptionFood =>
            _driver.FindElement(
                By.XPath("/html/body/div[5]/div/div/div[2]/div/div/div[5]/div/div/div/table/tbody/tr[4]"));
        private IWebElement TxtFoodQuantity => _driver.FindElement(By.XPath(
            "/html/body/div[5]/div/div/div[2]/div/div/div[7]/div/div[2]/div[3]/div[2]/div/div/div[3]/div[2]/div/input"));
        private IList<IWebElement> ListFoodUnit => _driver.FindElements(By.CssSelector("select[class='gwt-ListBox']"));
        private IWebElement BtnAddFoodToDiary => _driver.FindElement(By.XPath(
            "/html/body/div[5]/div/div/div[2]/div/div/div[7]/div/div[2]/div[3]/div[2]/div/div/div[3]/div[2]/div/div/button"));
        public AddFoodDialog(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddNewFood(string quantity, string foodUnit)
        {
            TdOptionFood.Click();
            TxtFoodQuantity.SendKeys(quantity);
            ListFoodUnit.FirstOrDefault(el => el.Text.Contains(foodUnit)).Click();
            BtnAddFoodToDiary.Click();
        }
    }
}
