using System.Xml.Serialization;
using SeleniumAutoTests.Base;
using SeleniumAutoTests.Data;

namespace SeleniumAutoTests.Tests
{
    [TestFixture]
    public class CreateTests : TestBase
    {
        public static IEnumerable<RoomData> RoomDataFromXmlFile()
        {
            using (StreamReader reader = new StreamReader(@"rooms.xml"))
            {
                return (List<RoomData>)new XmlSerializer(typeof(List<RoomData>)).Deserialize(reader);
            }
        }

        [Test, TestCaseSource(nameof(RoomDataFromXmlFile))]
        public void CreateRoomTest(RoomData newRoom)
        {
            AccountData admin = new("admin", "password");

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