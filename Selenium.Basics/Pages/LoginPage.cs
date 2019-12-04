using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Selenium.Basics.Pages
{
    public class LoginPage
    {
        public static IWebDriver WebDriver;

        public static bool IsLoading(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            return wait
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/app-root/section/app-login/div/div/div/div/form/div[3]/button")))
                .Displayed;
        }
        public static bool Login(string url, string username, string password)
        {
            WebDriver.Navigate().GoToUrl(url);
            WebDriver.Manage().Window.Maximize();

            WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-login/div/div/div/div/form/div[1]/input"))
                .SendKeys(username);
            WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-login/div/div/div/div/form/div[2]/input"))
                .SendKeys(password);

            var loginButton = WebDriver.FindElement(By.XPath("/html/body/app-root/section/app-login/div/div/div/div/form/div[3]/button"));

            ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].click()", loginButton);

            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            return wait
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("/html/body/app-root/section/app-booking-list/div[2]/div/div/div/form/div/div[3]/div/button")))
                .Displayed;
        }

    }
}
