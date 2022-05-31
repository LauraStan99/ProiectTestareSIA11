using System.Threading;
using OpenQA.Selenium;
using ProiectTestare.PageObjects.Home.InputData;

namespace ProiectTestare.PageObjects.Home.DialogPagesObjects
{
    public class AddExerciseDialog
    {
        private IWebDriver _driver;
        private IWebElement BtnCustomExercise => _driver.FindElement(By.XPath("/html/body/div[6]/div/div/div[2]/div/div[2]/div[1]/div/div/img"));
        private IWebElement TxtActivityName => _driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div[2]/div[2]/div[2]/div[2]/input"));
        private IWebElement TxtDuration => _driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/input"));
        private IWebElement TxtEnergyBurned => _driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div[2]/div[2]/div[2]/div[4]/input"));
        private IWebElement BtnAddExerciseToDiary => _driver.FindElement(By.XPath("/html/body/div[5]/div/div/div[2]/div/div[3]/button[2]"));

        public AddExerciseDialog(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddNewExercise(NewExcerciseBo exercise)
        {
            Thread.Sleep(2000);
            BtnCustomExercise.Click();

            TxtActivityName.Clear();
            TxtActivityName.SendKeys(exercise.ActivityName);

            TxtDuration.Clear();
            TxtDuration.SendKeys(exercise.EnergyBurned);

            TxtEnergyBurned.Click();
            TxtEnergyBurned.SendKeys(exercise.EnergyBurned);

            BtnAddExerciseToDiary.Click();
        }
    }
}
