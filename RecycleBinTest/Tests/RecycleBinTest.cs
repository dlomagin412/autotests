using DesktopAutoTests.Base;

namespace RecycleBinTest.Tests
{
    [TestFixture]
    public class RecycleBinTests : DesktopTestBase
    {
        [Test]
        public void EmptyRecycleBinTest()
        {
            recycleBin.EmptyBin();
            Assert.That(recycleBin.IsEmpty(), Is.True, "Корзина не очистилась или кнопка все еще активна!");
        }
    }
}