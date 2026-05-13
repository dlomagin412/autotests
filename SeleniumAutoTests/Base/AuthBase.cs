using SeleniumAutoTests.Data;
using SeleniumAutoTests.Helpers;

namespace SeleniumAutoTests.Base
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData admin = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(admin);
        }
    }
}