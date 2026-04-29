using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutoTests.Helpers;

namespace SeleniumAutoTests
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper auth;
        protected NavigationHelper navigation;
        protected RoomHelper room;

        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "https://automationintesting.online/admin/";

            auth = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            room = new RoomHelper(this);
        }

        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }
        public LoginHelper Auth { get { return auth; } }
        public NavigationHelper Navigation { get { return navigation; } }
        public RoomHelper Room { get { return room; } }
        ~AppManager()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {
                
            }
        }
    }
}