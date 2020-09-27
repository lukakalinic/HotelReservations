using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    /// <summary>
    /// Static class that consists only of string constants properties
    /// which we use in application to display error message.
    /// </summary>
    public static class ErrorMessage
    {
        public const string NumberOfRoomsInterval = "Number of rooms must be in interval [1,1000].";
        public const string StartDayGreaterThanZero = "Start day must be a number greater than zero.";
        public const string StartDayLessOrEqualsTo365 = "Start day must be a number less or equals to 365.";
        public const string EndDayGreaterThanZero = "End day must be a number greater than zero.";
        public const string EndDayLessOrEqualsTo365 = "End day must be a number less or equals to 365.";
        public const string StartDayGreaterThanEndDay = "Start day can't be greater then end day.";
    }
}
