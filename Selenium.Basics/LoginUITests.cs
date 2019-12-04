using OpenQA.Selenium;
using Selenium.Basics.Helpers;
using Selenium.Basics.Pages;
using System;
using Xunit;

namespace Selenium.Basics
{
    public class LoginUITests : IDisposable
    {
        private readonly string _url = "https://qa.soldev.uj.ac.za/ems/public/login";
        private readonly IWebDriver _driver;

        public LoginUITests()
        {
            _driver = DriverHelpers.GetChromeDriver();
            LoginPage.WebDriver = _driver;
        }

        [Fact]
        public void Login_WhenNagivatingToTheLoginPage_DisplayLoginPage()
        {
            Assert.True(LoginPage.IsLoading(_url));
        }

        [Fact]
        public void Login_WhenCorrectCredentialsAreSupplied_DisplayBookingsDashboardPage()
        {
            Assert.True(LoginPage.Login(_url,"lsetlhodi", "xxxx"));
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
