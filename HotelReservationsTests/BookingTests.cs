using CommonUtility;
using HotelReservations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HotelReservationsTests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        [TestCategory("ValidateBookingTests")]
        public void ValidateBooking_WithStartDayGreaterThanEndDay_ShouldThrowArgumentException()
        {
            Booking booking = new Booking(366, 5);

            try
            {
                booking.ValidateBooking();
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayGreaterThanEndDay);
            }
        }

        [TestMethod]
        [TestCategory("ValidateBookingTests")]
        public void ValidateBooking_WithNegativeStartDay_ShouldThrowArgumentOutOfRange()
        {
            Booking booking = new Booking(-1, 5);

            try
            {
                booking.ValidateBooking();
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayGreaterThanZero);
            }
        }

        [TestMethod]
        [TestCategory("ValidateBookingTests")]
        public void ValidateBooking_WithEndDayGreaterThan365_ShouldThrowArgumentOutOfRange()
        {
            Booking booking = new Booking(5, 366);

            try
            {
                booking.ValidateBooking();
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.EndDayLessOrEqualsTo365);
            }
        }

        [TestMethod]
        [TestCategory("ValidateBookingTests")]
        public void ValidateBooking_WithStartDayAndEndDayGreaterThan365_ShouldThrowArgumentOutOfRange()
        {
            Booking booking = new Booking(400, 500);

            try
            {
                booking.ValidateBooking();
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayLessOrEqualsTo365);
            }
        }

        [TestMethod]
        [TestCategory("ValidateBookingTests")]
        public void ValidateBooking_WithBothNegative_ShouldThrowArgumentOutOfRange()
        {
            Booking booking = new Booking(-6, -5);

            try
            {
                booking.ValidateBooking();
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayGreaterThanZero);
            }
        }
    }
}
