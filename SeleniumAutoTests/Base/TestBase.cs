using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumAutoTests.Data;


namespace SeleniumAutoTests.Base
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL = "https://automationintesting.online/admin/";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "#/admin");
        }

        public void Login(AccountData account)
        {
            FillTheField(By.Id("username"), account.Username);
            FillTheField(By.Id("password"), account.Password);
            driver.FindElement(By.Id("doLogin")).Click();
        }

        public void FillRoomForm(RoomData room)
        {
            FillTheField(By.Id("roomName"), room.RoomName);
            FillTheField(By.Id("roomPrice"), room.Price);

            if (room.HasWifi) driver.FindElement(By.Id("wifiCheckbox")).Click();
            if (room.HasTv) driver.FindElement(By.Id("tvCheckbox")).Click();
        }

        public void SubmitRoomCreation()
        {
            driver.FindElement(By.Id("createRoom")).Click();
        }

        public void FillTheField(By locator, string value)
        {
            if (value != null)
            {
                IWebElement field = driver.FindElement(locator);
                field.Clear();
                field.SendKeys(value);
            }
        }
    }
}