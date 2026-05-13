using System.Xml.Serialization;
using SeleniumAutoTests.Data;

namespace TestDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 5;
            string filename = "rooms.xml";

            List<RoomData> rooms = new List<RoomData>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                rooms.Add(new RoomData(rnd.Next(100, 1000).ToString(), rnd.Next(100, 500).ToString())
                {
                    HasWifi = true,
                    HasTv = true
                });
            }

            using (StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<RoomData>));
                serializer.Serialize(writer, rooms);
            }

            Console.ReadLine();
        }
    }
}