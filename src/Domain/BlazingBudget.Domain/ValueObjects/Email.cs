using Ardalis.GuardClauses;
using BlazingBudget.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int MaxLength = 256;

        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string input)
        {
            // TODO: How do we reuse these validation rules?

            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Email>(Messages.Strings.ValueIsRequired);

            string email = input.Trim();

            if (email.Length > MaxLength)
                return Result.Failure<Email>(Messages.Strings.ValueIsTooLong);

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Failure<Email>(Messages.Strings.ValueIsInvalid);

            return Result.Success(new Email(email));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
