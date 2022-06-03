using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home.DialogPagesObjects;
using ProiectTestare.PageObjects.Home.InputData;
using ProiectTestare.PageObjects.Settings;
using ProiectTestare.PageObjects.Shared.MenuController;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Home
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        private static By AddFoodOption => By.CssSelector("button[title='Log a serving to your diary']");
        private static By AddNewExerciseOption => By.CssSelector("button[title='Log an exercise to your diary']");
        private static By AddNewNoteOption => By.CssSelector("button[title='Log a note to your diary']");
        private static By GoToSettings => By.LinkText("Settings");
        private IWebElement BtnAddFood => _driver.FindElement(AddFoodOption);
        private IWebElement BtnAddNewExercise => _driver.FindElement(AddNewExerciseOption);
        private IWebElement BtnAddNewNote => _driver.FindElement(AddNewNoteOption);
        private IWebElement BtnGoToSettings => _driver.FindElement(GoToSettings);
       

        public HomePage(IWebDriver browserDriver)
        {
            _driver = browserDriver;
        }

        private LoggedInMenuController Menu => new LoggedInMenuController(_driver);

        public void AddFoodToDiary(string quantity)
        {
            _driver.WaitForElement(AddFoodOption);
            BtnAddFood.Click();
            var openAddFoodDialog = new AddFoodDialog(_driver);
            openAddFoodDialog.AddNewFood(quantity);

        }

        public void AddEcerciseToDiary(NewExcerciseBo exercise)
        {
            _driver.WaitForElement(AddNewExerciseOption);
            BtnAddNewExercise.Click();
            var openAddNewExerciseDialog = new AddExerciseDialog(_driver);
            openAddNewExerciseDialog.AddNewExercise(exercise);
        }

        public void AddNoteToDiary(string noteText)
        {
            _driver.WaitForElement(AddNewNoteOption);
            BtnAddNewNote.Click();
            var openAddNewNoteDialog = new AddNoteDialog(_driver);
            openAddNewNoteDialog.AddNewNote(noteText);
        }

        public SettingsPage NavigateToSettingsPage()
        {
            _driver.WaitForElement(GoToSettings);
            BtnGoToSettings.Click();
            return new SettingsPage(_driver);
        }
    }
}
