namespace SeleniumAutoTests.Base
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetUp()
        {
            app = new AppManager();
        }

        [TearDown]
        public void TearDown()
        {
            app.Stop();
        }
    }
}