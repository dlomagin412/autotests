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
            Thread.Sleep(2000);

            app.Room.InitRoomModification(newRoom.RoomName);
            Thread.Sleep(1000);

            RoomData actualRoom = app.Room.GetRoomDataFromEditForm();

            Assert.That(actualRoom.RoomName, Is.EqualTo(newRoom.RoomName));
            Assert.That(actualRoom.Price, Is.EqualTo(newRoom.Price));
            Assert.That(actualRoom.HasWifi, Is.EqualTo(newRoom.HasWifi));
            Assert.That(actualRoom.HasTv, Is.EqualTo(newRoom.HasTv));
        }
    }
}