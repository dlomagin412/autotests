using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAutoTests.Data;
using SeleniumAutoTests.Helpers;

namespace SeleniumAutoTests.Helpers
{
    public class RoomHelper : HelperBase
    {
        public RoomHelper(AppManager manager)
            : base(manager)
        {
        }

        public void FillRoomForm(RoomData room)
        {
            FillTheField(By.Id("roomName"), room.RoomName);
            FillTheField(By.Id("roomPrice"), room.Price);

            if (room.Type != null)
            {
                new SelectElement(driver.FindElement(By.Id("type"))).SelectByText(room.Type);
            }
            if (room.Accessible != null)
            {
                new SelectElement(driver.FindElement(By.Id("accessible"))).SelectByText(room.Accessible);
            }

            if (room.HasWifi) driver.FindElement(By.Id("wifiCheckbox")).Click();
            if (room.HasTv) driver.FindElement(By.Id("tvCheckbox")).Click();
            if (room.HasRadio) driver.FindElement(By.Id("radioCheckbox")).Click();
            if (room.HasRefresh) driver.FindElement(By.Id("refreshCheckbox")).Click();
            if (room.HasSafe) driver.FindElement(By.Id("safeCheckbox")).Click();
            if (room.HasViews) driver.FindElement(By.Id("viewsCheckbox")).Click();
        }

        public void SubmitRoomCreation()
        {
            driver.FindElement(By.Id("createRoom")).Click();
        }

        public void InitRoomModification(string roomName)
        {
            driver.FindElement(By.XPath($"//div[@data-testid='roomlisting']//p[text()='{roomName}']")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".btn-outline-primary")).Click();
        }

        public void SubmitRoomModification()
        {
            driver.FindElement(By.Id("update")).Click();
        }


        public void RemoveRoom(string roomName)
        {
            string xpath = $"//div[@data-testid='roomlisting'][.//p[text()='{roomName}']]//span[contains(@class, 'roomDelete')]";

            driver.FindElement(By.XPath(xpath)).Click();
        }
    }
}