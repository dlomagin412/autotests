using OpenQA.Selenium;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) { }

        public bool IsLoggedIn()
        {
            return driver.FindElements(By.XPath("//button[text()='Logout']")).Count > 0
                && driver.FindElements(By.Id("username")).Count == 0;
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                return;
            }

            
            if (driver.FindElements(By.XPath("//button[text()='Logout']")).Count > 0
                && driver.FindElements(By.Id("username")).Count > 0)
            {
                driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
                Thread.Sleep(1000);
            }

            if (driver.FindElements(By.Id("username")).Count == 0)
            {
                manager.Navigation.OpenHomePage();
                Thread.Sleep(1000);
            }

            FillTheField(By.Id("username"), account.Username);
            FillTheField(By.Id("password"), account.Password);
            driver.FindElement(By.Id("doLogin")).Click();

            int attempts = 0;
            while (driver.FindElements(By.Id("username")).Count > 0 && attempts < 10)
            {
                Thread.Sleep(500);
                attempts++;
            }
        }

        public void Logout()
        {
            if (driver.FindElements(By.XPath("//button[text()='Logout']")).Count > 0)
            {
                driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
                Thread.Sleep(1000);
                manager.Navigation.OpenHomePage();
            }
        }
    }
}