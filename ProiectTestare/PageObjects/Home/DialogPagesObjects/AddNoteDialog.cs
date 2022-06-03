using OpenQA.Selenium;
using ProiectTestare.Utils;

namespace ProiectTestare.PageObjects.Home.DialogPagesObjects
{
    public class AddNoteDialog
    {
        private readonly IWebDriver _driver;

        private static By TextareaForNote => By.CssSelector("textarea[maxlength='1000']");

        private IWebElement TxtTextareaForNote => _driver.FindElement(TextareaForNote);
        private IWebElement BtnSaveNote => _driver.FindElement(By.XPath("//button[@class='GO-RHEKCAHC btn-orange-flat']"));

        public AddNoteDialog(IWebDriver driver)
        {
            _driver = driver;
        }

        public void AddNewNote(string noteText)
        {   
            _driver.WaitForElement(TextareaForNote);
            TxtTextareaForNote.Clear();
            TxtTextareaForNote.SendKeys(noteText);

            BtnSaveNote.Click();
        }
    }
}
