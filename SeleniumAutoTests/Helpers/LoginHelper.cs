using OpenQA.Selenium;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) { }

        public bool IsLoggedIn()
        {
            return driver.FindElements(By.XPath("//button[text()='Logout']")).Count > 0;
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.XPath("//button[text()='Logout']")).Click();
                Thread.Sleep(2000);

                manager.Navigation.OpenHomePage();
                Thread.Sleep(1000);
            }
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account.Username))
                {
                    return;
                }
                Logout();
            }

            if (driver.FindElements(By.Id("username")).Count == 0)
            {
                manager.Navigation.OpenHomePage();
                Thread.Sleep(2000);
            }

            FillTheField(By.Id("username"), account.Username);
            FillTheField(By.Id("password"), account.Password);
            driver.FindElement(By.Id("doLogin")).Click();

            Thread.Sleep(3000);
        }
    }
}