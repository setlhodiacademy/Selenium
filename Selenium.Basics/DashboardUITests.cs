using OpenQA.Selenium;
using Selenium.Basics.Helpers;
using Selenium.Basics.Pages;
using System;
using Xunit;

namespace Selenium.Basics
{
    public class DashboardUITests : IDisposable
    {
        private readonly string _url = "https://qa.soldev.uj.ac.za/ems/public/login";
        private readonly IWebDriver _driver;

        public DashboardUITests()
        {
            _driver = DriverHelpers.GetChromeDriver();
            LoginPage.WebDriver = _driver;
            DashboardPage.WebDriver = _driver;
        }

        [Fact]
        public void FilterByStatus_WhenStatusIsSelectedByValue_ReturnFilteredResults()
        {
            LoginPage.Login(_url, "lsetlhodi", "xxxxx");
            DashboardPage.FilterByEvent("UJ Family day");
            // Assert.True(Dashboard_page.IsLoading(_url2));
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
