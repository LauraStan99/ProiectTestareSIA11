﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProiectTestare.Utils
{
    public static class Waits
    {
        private static bool IsAvailable(IWebElement element) =>
            element is { Displayed: true, Enabled: true };

        public static void WaitForElement(this IWebDriver driver, By by, int duration = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(duration))
            {
                PollingInterval = TimeSpan.FromMilliseconds(30)
            };

            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(condition =>
            {
                try
                {
                    var element = driver.FindElement(by);

                    if (IsAvailable(element))
                    {
                        return element;
                    }

                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
    }
}
