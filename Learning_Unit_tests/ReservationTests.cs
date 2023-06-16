using NUnit.Framework;
using TestesUnitários.Fundamentos;

namespace Learning_Unit_tests
{
    [TestFixture]
    public class ReservationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrange
                /*Instânciando a classe Reservation e User
                */
            var reservation = new Reservation();
            var user = new User { IsAdmin = true};

            // Act
                /* Chamando o método CanBeCancelledBy
                */
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnFalse()
        {
            //Arrange
            var reservation = new Reservation();
            var user = new User { IsAdmin = false };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user};
            
            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancellingTheReservation_ReturnFalse()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.That(result, Is.False);
        }
    }
}