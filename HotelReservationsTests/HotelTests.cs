using CommonUtility;
using HotelReservations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HotelReservationsTests
{
    [TestClass]
    public class HotelTests
    {
        [TestMethod]
        [TestCategory("CreateTests")]
        public void Create_WithValidNumberOfRooms()
        {
            uint numberOfRooms = 10;

            Hotel hotel = Hotel.Create(numberOfRooms);

            Assert.AreEqual(numberOfRooms * 366, Convert.ToUInt32(hotel.Rooms.Length));
        }

        [TestMethod]
        [TestCategory("CreateTests")]
        public void Create_WithNumberOfRoomsEqualToZero_ShouldThrowArgumentOutOfRange()
        {
            uint numberOfRooms = 0;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Hotel.Create(numberOfRooms));
        }

        [TestMethod]
        [TestCategory("CreateTests")]
        public void Create_WithNumberOfRoomsGreaterThanOneThousand_ShouldThrowArgumentOutOfRange()
        {
            uint numberOfRooms = 1001;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Hotel.Create(numberOfRooms));
        }

        [TestMethod]
        [TestCategory("FindFirstRoomWhichIsFreeAndReserveItTests")]
        public void CheckAvailabilityOfRooms_WithNegativeStartDay_ShouldThrowArgumentOutOfRange()
        {
            uint numberOfRooms = 10;
            Booking booking = new Booking(-1, 5);
            Hotel hotel = Hotel.Create(numberOfRooms);

            try
            {
                hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayGreaterThanZero);
            }
        }

        [TestMethod]
        [TestCategory("FindFirstRoomWhichIsFreeAndReserveItTests")]
        public void CheckAvailabilityOfRooms_WithEndDayGreaterThan365_ShouldThrowArgumentOutOfRange()
        {
            uint numberOfRooms = 10;
            Booking booking = new Booking(3, 366);
            Hotel hotel = Hotel.Create(numberOfRooms);

            try
            {
                hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.EndDayLessOrEqualsTo365);
            }
        }

        [TestMethod]
        [TestCategory("FindFirstRoomWhichIsFreeAndReserveItTests")]
        public void CheckAvailabilityOfRooms_WithStartDayGreaterThanEndDay_ShouldThrowArgumentException()
        {
            uint numberOfRooms = 10;
            Booking booking = new Booking(5, 4);
            Hotel hotel = Hotel.Create(numberOfRooms);

            try
            {
                hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, ErrorMessage.StartDayGreaterThanEndDay);
            }
        }

        [TestMethod]
        [TestCategory("FindFirstRoomWhichIsFreeAndReserveItTests")]
        public void CheckAvailabilityOfRooms_ReserveRoom_ExcepectToReturnZero()
        {
            uint numberOfRooms = 1;
            Booking booking = new Booking(3, 3);
            Hotel hotel = Hotel.Create(numberOfRooms);

            int actualValue = hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);

            Assert.AreEqual(0, actualValue);
        }

        [TestMethod]
        [TestCategory("FindFirstRoomWhichIsFreeAndReserveItTests")]
        public void CheckAvailabilityOfRooms_TryToReserveAlreadyReservedRoom_ExcepectToReturnNegative()
        {
            uint numberOfRooms = 1;
            Booking booking = new Booking(3, 3);
            Hotel hotel = Hotel.Create(numberOfRooms);

            hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            int actualValue = hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);

            Assert.AreEqual(-1, actualValue);
        }

        [TestMethod]
        [TestCategory("ReserveRoomTests")]
        public void ReserveRoom_ReserveOneRoom()
        {
            uint numberOfRooms = 1;
            Booking booking = new Booking(1, 1);
            Hotel hotel = Hotel.Create(numberOfRooms);

            hotel.ReserveRoom(0, booking);

            Assert.AreEqual(1, hotel.Rooms[0, 1]);
        }

        [TestMethod]
        [TestCategory("IsAlreadyInUseTests")]
        public void IsAlreadyInUse_ShouldReturnTrueForSameRoomOnSameDay()
        {
            uint numberOfRooms = 1;
            Booking booking = new Booking(1, 1);
            Hotel hotel = Hotel.Create(numberOfRooms);

            hotel.ReserveRoom(0, booking);
            bool except = hotel.IsAlreadyInUse(0, booking);

            Assert.AreEqual(true, except);
        }

        [TestMethod]
        [TestCategory("IsAlreadyInUseTests")]
        public void IsAlreadyInUse_ShouldReturnFalseForSameRoomOnSameDay()
        {
            uint numberOfRooms = 1;
            Booking booking1 = new Booking(1, 1);
            Booking booking2 = new Booking(2, 2);
            Hotel hotel = Hotel.Create(numberOfRooms);

            hotel.ReserveRoom(0, booking1);
            bool except = hotel.IsAlreadyInUse(0, booking2);

            Assert.AreEqual(false, except);
        }
    }
}
