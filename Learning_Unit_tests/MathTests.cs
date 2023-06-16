using NUnit.Framework;
using Math = TestesUnitários.Fundamentos.Math;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        // Utilizo o comando [Ignore("Because")] para não rodar determinado test.
        public void Add_WhenCalled_ReturnTheSumOfArguments() 
        {
            // Act
            var result = _math.Add(1, 2);

            // Asserts
            Assert.That(result, Is.EqualTo(3));
        
        }


        //Passando parâmetros para o teste
        //Nesse testes estamos executando 3 cenários diferentes
        [Test]
        [TestCase(5 , 2 , 5)] // a é maior que b
        [TestCase(4 , 8 , 8)] // a é menor que b
        [TestCase(4 , 4 , 4)] // a e b são iguais
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Max(a, b);

            // Asserts
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNembers(5);

            // Essas 3 Assertivas será subtituída por EquivalentTo
            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));

            //Verifica se o resultado está em ordenação crescente
            Assert.That(result, Is.Ordered);

            //Verifica se no array não possui numeração duplicada
            Assert.That(result, Is.Unique);
        }
    }
}
