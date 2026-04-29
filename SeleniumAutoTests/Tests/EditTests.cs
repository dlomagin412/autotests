using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class EditTests : TestBase
    {
        [Test]
        public void EditRoom()
        {
            AccountData admin = new("admin", "password");
            Random rnd = new();

            string oldNum = rnd.Next(100, 500).ToString();
            RoomData initialRoom = new(oldNum, "150");

            string newNum = rnd.Next(500, 1000).ToString();
            RoomData modifiedRoom = new(newNum, "300")
            {
                HasWifi = true,
                HasTv = true
            };

            app.Navigation.OpenHomePage();
            app.Auth.Login(admin);
            Thread.Sleep(1000);

            app.Room.FillRoomForm(initialRoom);
            app.Room.SubmitRoomCreation();
            Thread.Sleep(2000);

            app.Room.InitRoomModification(initialRoom.RoomName);
            Thread.Sleep(1000);

            app.Room.FillRoomForm(modifiedRoom);
            app.Room.SubmitRoomModification();
            Thread.Sleep(2000);

            app.Room.ClickEditButton();
            Thread.Sleep(1000);

            RoomData actualRoom = app.Room.GetRoomDataFromEditForm();

            Assert.That(actualRoom.RoomName, Is.EqualTo(modifiedRoom.RoomName));
            Assert.That(actualRoom.Price, Is.EqualTo(modifiedRoom.Price));
            Assert.That(actualRoom.HasWifi, Is.EqualTo(modifiedRoom.HasWifi));
            Assert.That(actualRoom.HasTv, Is.EqualTo(modifiedRoom.HasTv));
        }
    }
}