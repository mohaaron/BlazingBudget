using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueObjects
{
    public class Password : Abp.Domain.Values.ValueObject
    {
        public Password(string value)
        {
            Value = Guard.Against.InvalidFormat(value, nameof(value), "regex for string password"); ;
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
