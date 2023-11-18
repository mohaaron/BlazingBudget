using CSharpFunctionalExtensions;
using BlazingBudget.Domain.Common;

namespace BlazingBudget.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        public const int MaxLength = 256;

        private Email() { }

        [JsonConstructor]
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
