using OpenQA.Selenium;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager)
            : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            FillTheField(By.Id("username"), account.Username);
            FillTheField(By.Id("password"), account.Password);
            driver.FindElement(By.Id("doLogin")).Click();
        }
    }
}