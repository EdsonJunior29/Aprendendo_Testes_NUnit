
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;

namespace Learning_Unit_tests.Mocking
{
    [TestFixture]
    public class BookingHelper_OverlappingBookingsExistTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _booking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2023, 1, 15),
                DepartureDate = DepartureOn(2023, 1, 20),
                Reference = "a"
            };

            //Simulando o retorno da consulta ao banco de dados
            _repository = new Mock<IBookingRepository>();
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking> { _booking }.AsQueryable());
        }


        [Test]
        public void BookingsOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = AfterDate(_booking.DepartureDate),
                     DepartureDate = AfterDate(_booking.DepartureDate, days: 2),
                     Status = "Cancelled"
                 }, _repository.Object);

            Assert.That(result, Is.Empty);
        }


        [Test]
        public void BookingStartsAndFinishesBeforeAnExistinBooking_ReturnEmptyString()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 2,
                     ArrivalDate = BeforeDate(_booking.ArrivalDate, days: 2),
                     DepartureDate = BeforeDate(_booking.DepartureDate),
                     Reference = "a"
                 }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistinBooking_ReturnReference()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = BeforeDate(_booking.ArrivalDate),
                     DepartureDate = BeforeDate(_booking.DepartureDate),
                     Reference = "a"
                 }, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistinBooking_ReturnReference()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = BeforeDate(_booking.ArrivalDate),
                     DepartureDate = AfterDate(_booking.DepartureDate),
                 }, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesInTheMiddleAnExistinBooking_ReturnReference()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = AfterDate(_booking.ArrivalDate),
                     DepartureDate = BeforeDate(_booking.DepartureDate),
                 }, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsInTheMiddleOfAnExistingBookingButFinishedAfter_ReturnReference()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = AfterDate(_booking.ArrivalDate),
                     DepartureDate = AfterDate(_booking.DepartureDate),
                 }, _repository.Object);

            Assert.That(result, Is.EqualTo(_booking.Reference));
        }

        [Test]
        public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            //Chamando o método OverlappingBookingsExits classe BookingHelper
            var result = BookingHelper.OverlappingBookingsExits(
                 new Booking
                 {
                     Id = 1,
                     ArrivalDate = AfterDate(_booking.DepartureDate),
                     DepartureDate = AfterDate(_booking.DepartureDate, days: 2),
                 }, _repository.Object);

            Assert.That(result, Is.Empty);
        }

        private DateTime ArriveOn(int year, int month, int day)
        { 
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartureOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        private DateTime BeforeDate(DateTime dateTime, int days = 1)
        { 
            return dateTime.AddDays(-days);
        
        }

        private DateTime AfterDate(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(+days);

        }
    }
}
