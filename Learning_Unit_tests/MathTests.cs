using Math = TestesUnitários.Fundamentos.Math;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class MathTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments() 
        {
            //Arrange
            var math = new Math();

            // Act
            var result = math.Add(1, 2);

            // Asserts
            Assert.That(result, Is.EqualTo(3));
        
        }

        [Test]
        public void Add_WhenCalled_ReturnTheHigherNumber()
        {
            //Arrange
            var math = new Math();

            // Act
            var result = math.Max(1, 2);

            // Asserts
            Assert.That(result, Is.EqualTo(2));

        }
    }
}
