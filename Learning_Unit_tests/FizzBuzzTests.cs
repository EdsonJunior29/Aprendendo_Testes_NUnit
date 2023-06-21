
using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [SetUp]
        public void Setup()
        {}

        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz() 
        {
            var fizzBuzz = FizzBuzz.GetOutout(15);

            Assert.That(fizzBuzz, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            var fizzBuzz = FizzBuzz.GetOutout(21);

            Assert.That(fizzBuzz, Is.EqualTo("Fizz"));
        }


        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            var fizzBuzz = FizzBuzz.GetOutout(20);

            Assert.That(fizzBuzz, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnNumberConvertedToString()
        {
            var fizzBuzz = FizzBuzz.GetOutout(23);

            Assert.That(fizzBuzz, Is.EqualTo("23"));
        }
    }
}
