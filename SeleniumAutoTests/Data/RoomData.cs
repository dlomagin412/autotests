namespace SeleniumAutoTests.Data
{
    public class RoomData
    {
        public string RoomName { get; set; }
        public string Price { get; set; }
        public bool HasWifi { get; set; }
        public bool HasTv { get; set; }

        public RoomData(string roomName, string price)
        {
            RoomName = roomName;
            Price = price;
        }
    }
}