using CommonUtility;
using System;

namespace HotelReservations
{
    public class Hotel
    {
        private int guestNumber = 1;
        private int maxEndDate = 0;
        private uint numberOfRooms;
        public int[,] Rooms { get; }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="numberOfRooms"></param>
        private Hotel(uint numberOfRooms)
        {
            this.numberOfRooms = numberOfRooms;
            this.Rooms = new int[numberOfRooms, 366];
        }

        /// <summary>
        /// Static method which we use to create instance of Hotel object.
        /// This method calls private constructor and returns instance of Hotel.
        /// </summary>
        /// <param name="numberOfRooms"></param>
        /// <returns></returns>
        public static Hotel Create(uint numberOfRooms)
        {
            if (numberOfRooms < 1 || numberOfRooms > 1000)
            {
                throw new ArgumentOutOfRangeException("numberOfRooms", numberOfRooms, ErrorMessage.NumberOfRoomsInterval);
            }

            return new Hotel(numberOfRooms);
        }

        /// <summary>
        /// This method books first free room for a given booking.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>Returns -1 if there is no room to be booked. Else returns number >= 0
        /// which is number of the room.</returns>
        public int FindFirstRoomWhichIsFreeAndReserveIt(Booking booking)
        {
            booking.ValidateBooking();

            for (int i = 0; i < numberOfRooms; i++)
            {
                if (this.Rooms[i, booking.StartDay] == 0 && this.Rooms[i, booking.EndDay] == 0 && !IsAlreadyInUse(i, booking))
                {
                    ReserveRoom(i, booking);

                    guestNumber++;
                    if (booking.EndDay > maxEndDate)
                        maxEndDate = booking.EndDay;

                    return i;
                }
                else
                    continue;
            }

            return -1;
        }

        /// <summary>
        /// This method reserves room with number roomNumber for given days.
        /// </summary>
        /// <param name="roomNumber">Room number</param>
        /// <param name="booking"></param>
        public void ReserveRoom(int roomNumber, Booking booking)
        {
            for (int i = booking.StartDay; i <= booking.EndDay; i++)
            {
                this.Rooms[roomNumber, i] = guestNumber;
            }
        }

        /// <summary>
        /// This method checks if the room with given number is already reserved.
        /// </summary>
        /// <param name="roomNumber">Room number</param>
        /// <returns>Returns true if the room is alreadey in use. Else returns false.</returns>
        public bool IsAlreadyInUse(int roomNumber, Booking booking)
        {
            for (int i = booking.StartDay; i <= booking.EndDay; i++)
            {
                if (this.Rooms[roomNumber, i] != 0)
                    return true;
                else
                    continue;
            }

            return false;
        }

        /// <summary>
        /// Utility method which presents the hotel in shape of matrix.
        /// Rows are room numbers.
        /// Columuns are days from interval [0,365]
        /// </summary>
        public void TableViewOfAllRooms()
        {
            for (int i = 0; i < numberOfRooms; i++)
            {
                Console.Write($"Room{i} | ");

                for (int j = 0; j <= maxEndDate; j++)
                    Console.Write($"{this.Rooms[i, j]} ");

                Console.WriteLine("");
            }
        }
    }
}