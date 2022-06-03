using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Home.DialogPagesObjects
{
    internal class AddFoodDialog
    {
        private readonly IWebDriver _driver;

        private static By FoodQuantity => By.CssSelector("input[maxlength='6']");
        private static By AddFoodToDiary => By.XPath("/html/body/div[5]/div/div/div[2]/div/div/div[7]/div/div[2]/div[3]/div[2]/div/div/div[3]/div[2]/div/div/button");
        private static By FoodTableContent => By.CssSelector("table[class='prettyTable']");

        private IWebElement TableFood => _driver.FindElement(FoodTableContent);
        private IWebElement TxtFoodQuantity => _driver.FindElement(FoodQuantity);
        private IWebElement BtnAddFoodToDiary => _driver.FindElement(AddFoodToDiary);

        public AddFoodDialog(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddNewFood(string quantity)
        {
            _driver.WaitForElement(FoodTableContent);
            var rows = TableFood.FindElements(By.ClassName("evenrow"));
            var foodSelected= rows.Select(food => food.FindElement(By.XPath("/html/body/div[6]/div/div/div[2]/div/div/div[5]/div/div/div/table/tbody/tr[5]/td[1]/div"))).FirstOrDefault();
            foodSelected.Click();

            _driver.WaitForElement(FoodQuantity);
            TxtFoodQuantity.SendKeys(quantity);

            _driver.WaitForElement(AddFoodToDiary);
            BtnAddFoodToDiary.Click();
        }
    }
}
