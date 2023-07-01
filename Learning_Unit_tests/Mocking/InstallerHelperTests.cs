
using Moq;
using System.Net;
using TestesUnitários.Mocking;

namespace Learning_Unit_tests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        { 
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_WhereDownloadFail_ReturnFalse()
        {
            // criando o Mock
            // It.IsAny<string>() = Forma genérica de passar parâmetros
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsFalse(result);

        }

        [Test]
        public void DownloadInstaller_WhereDownloadCompletes_ReturnTrue()
        {
           
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.IsTrue(result);

        }
    }
}
