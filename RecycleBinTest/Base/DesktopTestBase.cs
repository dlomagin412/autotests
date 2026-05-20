using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using DesktopAutoTests.Helpers;

namespace DesktopAutoTests.Base
{
    public class DesktopTestBase
    {
        protected WindowsDriver<WindowsElement> session;
        protected RecycleBinHelper recycleBin;
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";

        [SetUp]
        public void SetUp()
        {
            if (session == null)
            {
                var appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("app", "explorer.exe");
                appOptions.AddAdditionalCapability("appArguments", "shell:RecycleBinFolder");
                appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appOptions);
                session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                
                recycleBin = new RecycleBinHelper(session);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (session != null)
            {
                session.Quit();
                session.Dispose();
                session = null;
            }
        }
    }
}