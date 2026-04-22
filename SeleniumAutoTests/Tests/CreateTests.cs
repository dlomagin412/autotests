using NUnit.Framework;
using System.Threading;
using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class CreateTests : TestBase
    {
        [Test]
        public void CreateRoomTest()
        {
            AccountData admin = new("admin", "password");
            string roomNum = new Random().Next(100, 1000).ToString();
            RoomData newRoom = new(roomNum, "200") { HasWifi = true, HasTv = true };

            app.Navigation.OpenHomePage();
            app.Auth.Login(admin);

            Thread.Sleep(1000);

            app.Room.FillRoomForm(newRoom);
            app.Room.SubmitRoomCreation();
        }
    }
}