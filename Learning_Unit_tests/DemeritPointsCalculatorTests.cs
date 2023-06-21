
using NUnit.Framework;
using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    internal class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;
        [SetUp]
        public void Setup()
        { 
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException() 
        {  
           Assert.That(() => _calculator.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_SpeedIsOver300_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _calculator.CalculateDemeritPoints(301), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_WhenCalled_ReturnZero()
        {
            var result = _calculator.CalculateDemeritPoints(50);
            Assert.That(result, Is.Zero);
        }

        [Test]
        [TestCase(100 , 7)]
        [TestCase(180 , 23)]
        [TestCase(300 , 47)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
