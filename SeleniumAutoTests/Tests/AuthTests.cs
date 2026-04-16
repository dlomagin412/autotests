using NUnit.Framework;
using OpenQA.Selenium;
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
            AccountData admin = new AccountData("admin", "password");

            OpenHomePage();
            Login(admin);
        }
    }
}