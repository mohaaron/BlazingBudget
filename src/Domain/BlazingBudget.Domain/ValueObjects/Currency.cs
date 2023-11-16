using Abp;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// Is currency an aggregate?
    /// </summary>
    public class Currency : Abp.Domain.Values.ValueObject
    {
        private Currency() { }

        internal Currency(string name, string currencyCode)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            CurrencyCode = Check.NotNullOrWhiteSpace(currencyCode, nameof(currencyCode));
            //Rate = Guard.Against.NegativeOrZero(rate, nameof(rate), "Rate must be larger than zero.");
        }

        public string Name { get; private set; }
        public string CurrencyCode { get; private set; }
        //public decimal Rate { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return CurrencyCode;
            //yield return Rate;
        }
    }
}
