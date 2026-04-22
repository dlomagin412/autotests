using NUnit.Framework;
using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class AuthTests : TestBase
    {
        [Test]
        public void LoginTest()
        {
            AccountData admin = new("admin", "password");

            app.Navigation.OpenHomePage();
            app.Auth.Login(admin);
        }
    }
}