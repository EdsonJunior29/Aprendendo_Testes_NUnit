
using TestesUnitários.Mocking;

namespace Learning_Unit_tests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        { 
            var service = new VideoService();

            var result = service.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

    }
}
