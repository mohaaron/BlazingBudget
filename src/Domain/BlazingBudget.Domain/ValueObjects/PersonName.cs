using Abp;
using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueObjects
{
    public class PersonName : Abp.Domain.Values.ValueObject
    {
        private static readonly int MaxLength = 300;

        private PersonName() { }

        private PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static IResult<PersonName> Create(string firstName, string lastName)
        {
            // TODO: How do we reuse these validation rules?

            if (firstName.Length > MaxLength)
            {
                return Result.Failure<PersonName>("First name must be less than 300 charactors");
            }

            if (lastName.Length > MaxLength)
            {
                return Result.Failure<PersonName>("Last name must be less than 300 charactors");
            }

            return Result.Success(new PersonName(firstName, lastName));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{FirstName} {LastName}";

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
