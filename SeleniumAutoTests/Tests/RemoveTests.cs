using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class RemoveTests : AuthBase
    {
        [Test]
        public void RemoveRoom()
        {
            string roomToDelete = new Random().Next(100, 1000).ToString();
            RoomData newRoom = new(roomToDelete, "100");

            app.Room.FillRoomForm(newRoom);
            app.Room.SubmitRoomCreation();
            Thread.Sleep(1000);

            app.Room.RemoveRoom(newRoom.RoomName);

            Thread.Sleep(1000);
            Assert.That(app.Driver.PageSource, Does.Not.Contain(newRoom.RoomName));
        }
    }
}