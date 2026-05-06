namespace SeleniumAutoTests.Data
{
    public class RoomData
    {
        public string RoomName { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string Accessible { get; set; }
        public bool HasWifi { get; set; }
        public bool HasTv { get; set; }
        public bool HasRadio { get; set; }
        public bool HasRefresh { get; set; }
        public bool HasSafe { get; set; }
        public bool HasViews { get; set; }

        public RoomData()
        {
        }

        public RoomData(string roomName, string price)
        {
            RoomName = roomName;
            Price = price;
        }
    }
}