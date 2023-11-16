using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Exceptions
{
    public class MustBeLargerThanZeroException : ArgumentException
    {
        public MustBeLargerThanZeroException(object value) : base("Value must be larger than zero: {value}", nameof(value))
        { }
    }
}
