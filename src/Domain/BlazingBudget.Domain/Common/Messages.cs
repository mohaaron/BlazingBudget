using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Common
{
    /// <summary>
    /// These types of values should be in AppSettings or even in a db table
    /// </summary>
    public static class Messages
    {
        public static class Strings
        {
            public static string ValueIsRequired = "A value is required";
            public static string ValueIsTooLong = "The value entered is too long";
            public static string ValueIsInvalid = "An invalid value was entered";
        }

        public static class Numbers
        {
            public static string MustBeLargerThanZero = "The value must be larger than zero";
        }
    }
}
