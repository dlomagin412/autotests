using OpenQA.Selenium;
using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class RoomTests : TestBase
    {
        [Test]
        public void CreateRoomTest()
        {
            AccountData admin = new AccountData("admin", "password");
            RoomData newRoom = new RoomData("104", "200") { HasWifi = true, HasTv = true };

            OpenHomePage();
            Login(admin);

            Thread.Sleep(1000);

            FillRoomForm(newRoom);
            SubmitRoomCreation();
        }
    }
}