using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home.DialogPagesObjects;
using ProiectTestare.PageObjects.Home.InputData;

namespace ProiectTestare.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver _driver;
        private IWebElement BtnAddFood => _driver.FindElement(By.CssSelector("button[title='Log a serving to your diary']"));
        private IWebElement BtnAddNewExercise => _driver.FindElement(By.CssSelector("button[title='Log an exercise to your diary']"));
       

        public HomePage(IWebDriver browserDriver)
        {
            _driver = browserDriver;
        }

        public void AddFoodToDiary(string quantity, string foodUnit)
        {
            BtnAddFood.Click();
            var openAddFoodDialog = new AddFoodDialog(_driver);
            openAddFoodDialog.AddNewFood(quantity, foodUnit);

        }

        public void AddEcerciseToDiary(NewExcerciseBo exercise)
        {
            BtnAddNewExercise.Click();
            var openAddNewExerciseDialog = new AddExerciseDialog(_driver);
            openAddNewExerciseDialog.AddNewExercise(exercise);
        }
    }
}
