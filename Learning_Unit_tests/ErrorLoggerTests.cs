
using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;
        [SetUp]
        public void Setup()
        {
            _errorLogger = new ErrorLogger();
        }
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty() 
        {
            _errorLogger.Log("a");

            Assert.That(_errorLogger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)] //valor null
        [TestCase("")] // valor em branco
        [TestCase(" ")] // espaço => WhiteSpace
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            //Para métodos que lançam exception utilizamos os Delegate nas Asserts
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }
    }
}
