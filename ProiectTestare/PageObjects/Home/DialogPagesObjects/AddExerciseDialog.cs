using System.Threading;
using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home.InputData;
using ProiectTestare.Tests.Shared;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Home.DialogPagesObjects
{
    public class AddExerciseDialog
    {
        private readonly IWebDriver _driver;
        private static By AddCustomExerciseIcon => By.CssSelector($"img[src='{Constants.PathIconAddCustomExercise}']");
        private static By AddExerciseToDiary => By.CssSelector("button[class='gwt-SubmitButton btn-green-flat']");

        private IWebElement BtnCustomExercise => _driver.FindElement(AddCustomExerciseIcon);
        private IWebElement TxtActivityName => _driver.FindElement(By.CssSelector("body > div.prettydialog > div > div > div.GO-RHEKCM-C > div > div.GO-RHEKCA0C.GO-RHEKCC0C > div.GO-RHEKCLYC > div.GO-RHEKCA-C > div:nth-child(2) > input"));
        private IWebElement TxtDuration => _driver.FindElement(By.CssSelector("input[max='9999']"));
        private IWebElement TxtEnergyBurned => _driver.FindElement(By.CssSelector("body > div.prettydialog > div > div > div.GO-RHEKCM-C > div > div.GO-RHEKCA0C.GO-RHEKCC0C > div.GO-RHEKCLYC > div.GO-RHEKCA-C > div.GO-RHEKCB-C > input"));
        private IWebElement BtnAddExerciseToDiary => _driver.FindElement(AddExerciseToDiary);

        public AddExerciseDialog(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddNewExercise(NewExcerciseBo exercise)
        {
            _driver.WaitForElement(AddCustomExerciseIcon); 
            BtnCustomExercise.Click();

            TxtActivityName.Clear();
            TxtActivityName.SendKeys(exercise.ActivityName);

            TxtDuration.Clear();
            TxtDuration.SendKeys(exercise.EnergyBurned);

            TxtEnergyBurned.Clear();
            TxtEnergyBurned.SendKeys(exercise.EnergyBurned);

            _driver.WaitForElement(AddExerciseToDiary);
            BtnAddExerciseToDiary.Click();
        }
    }
}
