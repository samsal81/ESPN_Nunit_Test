using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESPN_Nunit_Test
{
    public class TestBase
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            //maximizing the window
            driver.Manage().Window.Maximize();

            //clear cache
            driver.Manage().Cookies.DeleteAllCookies();

            //navidating to page
            driver.Navigate().GoToUrl("http://espn.com");

            //setting implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
