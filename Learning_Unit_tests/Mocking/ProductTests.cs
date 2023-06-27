
using Moq;
using TestesUnitários.Mocking;

namespace Learning_Unit_tests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        /* Essa é a melhor abordagem para a criação de um teste */
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount() 
        {
            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }

        /* Teste semelhante ao de cima. Mas nesse estarei utilizando MOCK */
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        {
            // Mock da Interface
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
