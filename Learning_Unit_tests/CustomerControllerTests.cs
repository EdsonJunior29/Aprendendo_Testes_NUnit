
using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = _controller.GetCustomer(0);

            //Informa que o resultado e exatemente daquele Tipo de objeto
            Assert.That(result, Is.TypeOf<NotFound>());

            // Pode ser NotFound object (Não e com exatidão)
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnNotFound()
        {
            var result = _controller.GetCustomer(5);

            Assert.That(result, Is.TypeOf<OK>());
        }
    }
}
