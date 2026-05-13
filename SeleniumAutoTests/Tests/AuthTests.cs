using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;
using SeleniumAutoTests.Helpers;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class AuthTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            app.Auth.Logout();

            AccountData admin = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(admin);

            Assert.That(app.Auth.IsLoggedIn(), Is.True);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();

            AccountData invalidUser = new AccountData("admin", "wrong_pass");
            app.Auth.Login(invalidUser);

            Assert.That(app.Auth.IsLoggedIn(), Is.False);
        }
    }
}