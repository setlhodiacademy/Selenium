using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace Selenium.Basics.Pages
{
    public class DashboardPage
    {
        
        public static IWebDriver WebDriver;
   
        private static void SelectBookingStatusByValue(string value)
        {    
            var drpBookingStatus = new SelectElement(WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[1]/div/select")));
            drpBookingStatus.SelectByValue(value);
        }

        private static void SelectBookingStatusByDisplayText(string displayText)
        {
            var drpBookingStatus = new SelectElement(WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[1]/div/select")));
            drpBookingStatus.SelectByText(displayText);
        }
        private static void FillInEventName(string eventName)
        {
            WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[2]/div/input"))
                .SendKeys(eventName);
        }

        private static void ClickOnFilterButton()
        {
            var filterButton = WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[3]/div/button"));

            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click()", filterButton);
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            //var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            //return wait
            //    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[3]/div/button")))
            //    .Displayed;
        }

        public static void FilterByStatus(string status)
        {
            SelectBookingStatusByValue(status);
            ClickOnFilterButton();
        }

        public static void FilterByEvent(string eventName)
        {
            FillInEventName(eventName);
            ClickOnFilterButton();
        }

        public static void FilterByAll(string status, string eventName)
        {
            SelectBookingStatusByValue(status);
            FillInEventName(eventName);
            ClickOnFilterButton();
        }
    }
}
