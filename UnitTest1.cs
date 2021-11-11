using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace ESPN_Nunit_Test
{
    public class Tests
    {
        IWebDriver driver;

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

        [Test]
        public void Test1()
        {
            //storing locator 
            IWebElement TopHeadline = driver.FindElement(By.XPath("//div/section[3]/div[1]/section/ul/li[1]/a"));
            String headlinetxt = TopHeadline.Text;

            //initiating the screenshot
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();

            //saving the screenshot
            image.SaveAsFile("C:\\Users\\Samsa\\source\\repos\\nunittemp\\data\\pic.png", ScreenshotImageFormat.Png);
            TopHeadline.Click();

            //writing the headline to console
            Console.WriteLine("Top Headline is: " + headlinetxt);

            //initiating file creation
            FileStream f = new FileStream("C:\\Users\\Samsa\\source\\repos\\nunittemp\\data\\Logoutput.txt", FileMode.Create);

            //writing the headline to file
            StreamWriter s = new StreamWriter(f);
            s.WriteLine(headlinetxt);

            //closing writer and file
            s.Close();
            f.Close();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}