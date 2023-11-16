using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueObjects
{
    public class PersonFullName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }

        protected PersonFullName()
        : this("", "")
        {
        }

        internal PersonFullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<PersonFullName> Create(string firstName, string lastName)
        {
            firstName = (firstName ?? "").Trim();
            lastName = (lastName ?? "").Trim();

            if (firstName.Length > 60) return Result.Failure<PersonFullName>($"{nameof(firstName)} is too long");
            if (firstName.Length == 0) return Result.Failure<PersonFullName>($"{nameof(firstName)} is empty");

            if (lastName.Length > 60) return Result.Failure<PersonFullName>($"{nameof(lastName)} is too long");
            if (lastName.Length == 0) return Result.Failure<PersonFullName>($"{nameof(lastName)} is empty");

            if (firstName.Equals(lastName, StringComparison.OrdinalIgnoreCase)) return Result.Failure<PersonFullName>($"{nameof(firstName)} should not be equal to {nameof(lastName)}");

            return Result.Success(new PersonFullName(firstName, lastName));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }

        public static implicit operator string(PersonFullName fullName) => $"{fullName.FirstName} {fullName.LastName}"; // every fullName is a string
    }
}
