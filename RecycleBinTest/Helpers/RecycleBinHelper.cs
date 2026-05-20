using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace DesktopAutoTests.Helpers
{
    public class RecycleBinHelper(WindowsDriver<WindowsElement> driver)
    {
        private WebDriverWait wait = new(driver, TimeSpan.FromSeconds(5));
        
        public bool IsEmpty()
        {
            try
            {
                var emptyButton = driver.FindElementByName("Очистить корзину");
                return !emptyButton.Enabled;
            }
            catch (WebDriverException)
            {
                return true; 
            }
            catch (Exception)
            {
                return true;
            }
        }

        public void EmptyBin()
        {
            if (IsEmpty()) 
            {
                return;
            }

            driver.FindElementByName("Очистить корзину").Click();
            var yesButton = wait.Until(d => d.FindElement(By.Name("Да")));
            yesButton.Click();
        }
    }
}