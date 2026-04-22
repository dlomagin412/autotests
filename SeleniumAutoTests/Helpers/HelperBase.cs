using OpenQA.Selenium;

namespace SeleniumAutoTests.Helpers
{
    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public void FillTheField(By locator, string value)
        {
            if (value != null)
            {
                IWebElement field = driver.FindElement(locator);
                field.Clear();
                field.SendKeys(value);
            }
        }
    }
}