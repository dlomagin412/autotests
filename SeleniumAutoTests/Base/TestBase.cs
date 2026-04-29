namespace SeleniumAutoTests.Base
{
    public class TestBase
    {
        protected AppManager app; [SetUp]
        public void SetUp()
        {
            app = AppManager.GetInstance();
        }
    }
}
