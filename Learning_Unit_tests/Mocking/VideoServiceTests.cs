
using Moq;
using TestesUnitários.Mocking;

namespace Learning_Unit_tests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        { 
            // Criando um dinâmico mock
            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var service = new VideoService(fileReader.Object);

            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

    }
}
