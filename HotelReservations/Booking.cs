using CommonUtility;
using System;

namespace HotelReservations
{
    public class Booking
    {
        public int StartDay { get; }
        public int EndDay { get; }

        public Booking(int startDay, int endDay)
        {
            this.StartDay = startDay;
            this.EndDay = endDay;
        }

        /// <summary>
        /// Validates values of StartDay and EndDay properties.
        /// </summary>
        public void ValidateBooking()
        {
            if (this.StartDay > this.EndDay)
            {
                throw new ArgumentException(ErrorMessage.StartDayGreaterThanEndDay);
            }
            else if (this.StartDay < 0)
            {
                throw new ArgumentOutOfRangeException("startDay", this.StartDay, ErrorMessage.StartDayGreaterThanZero);
            }
            else if (this.StartDay > 365)
            {
                throw new ArgumentOutOfRangeException("startDay", this.StartDay, ErrorMessage.StartDayLessOrEqualsTo365);
            }
            else if (this.EndDay > 365)
            {
                throw new ArgumentOutOfRangeException("endDay", this.EndDay, ErrorMessage.EndDayLessOrEqualsTo365);
            }
        }
    }
}
