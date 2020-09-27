using System;
using System.Collections.Generic;

namespace HotelReservations
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAllTestsAndDisplayResults();

            Console.ReadKey();
        }

        #region Methods for different test cases

        private static void testCase1()
        {
            Hotel hotel = Hotel.Create(1);
            Booking booking = new Booking(-4, 2);

            try
            {
                hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            }
            catch (Exception)
            {
                Console.WriteLine($"(Booking1, {booking.StartDay}, {booking.EndDay}, Decline)");
            }

            Console.WriteLine();

            hotel.TableViewOfAllRooms();
        }

        private static void testCase2()
        {
            Hotel hotel = Hotel.Create(1);
            Booking booking = new Booking(200, 400);

            try
            {
                hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking);
            }
            catch (Exception)
            {
                Console.WriteLine($"(Booking1, {booking.StartDay}, {booking.EndDay}, Decline)");
            }

            Console.WriteLine();

            hotel.TableViewOfAllRooms();
        }

        private static void testCase3()
        {
            Hotel hotel = Hotel.Create(3);
            List<Booking> bookings = new List<Booking>()
            {
                new Booking(0, 5),
                new Booking(7, 13),
                new Booking(3, 9),
                new Booking(5, 7),
                new Booking(6, 6),
                new Booking(0, 4)
            };

            int i = 1;
            foreach (Booking booking in bookings)
            {
                if (hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking) != -1)
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Accept)");
                }
                else
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Decline)");
                }
            }

            Console.WriteLine();

            hotel.TableViewOfAllRooms();
        }

        private static void testCase4()
        {
            Hotel hotel = Hotel.Create(3);
            List<Booking> bookings = new List<Booking>()
            {
                new Booking(1, 3),
                new Booking(0, 15),
                new Booking(1, 9),
                new Booking(2, 5),
                new Booking(4, 9)
            };

            int i = 1;
            foreach (Booking booking in bookings)
            {
                if (hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking) != -1)
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Accept)");
                }
                else
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Decline)");
                }
            }

            Console.WriteLine();

            hotel.TableViewOfAllRooms();
        }

        private static void testCase5()
        {
            Hotel hotel = Hotel.Create(2);
            List<Booking> bookings = new List<Booking>()
            {
                new Booking(1, 3),
                new Booking(0, 4),
                new Booking(2, 3),
                new Booking(5, 5),
                new Booking(4, 10),
                new Booking(10, 10),
                new Booking(6, 7),
                new Booking(8, 10),
                new Booking(8, 9)
            };

            int i = 1;
            foreach (Booking booking in bookings)
            {
                if (hotel.FindFirstRoomWhichIsFreeAndReserveIt(booking) != -1)
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Accept)");
                }
                else
                {
                    Console.WriteLine($"(Booking{i++}, {booking.StartDay}, {booking.EndDay}, Decline)");
                }
            }

            Console.WriteLine();

            hotel.TableViewOfAllRooms();
        }

        #endregion

        private static void RunAllTestsAndDisplayResults()
        {
            Console.WriteLine("Running tests...\n");

            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("Test Case 1:");
            testCase1();

            Console.WriteLine("\n----------------------------------------------------");

            Console.WriteLine("\nTest Case 2:");
            testCase2();

            Console.WriteLine("\n----------------------------------------------------");

            Console.WriteLine("\nTest Case 3:");
            testCase3();

            Console.WriteLine("\n----------------------------------------------------");

            Console.WriteLine("\nTest Case 4:");
            testCase4();

            Console.WriteLine("\n----------------------------------------------------");

            Console.WriteLine("\nTest Case 5:");
            testCase5();

            Console.WriteLine("\n----------------------------------------------------");
        }
    }
}
