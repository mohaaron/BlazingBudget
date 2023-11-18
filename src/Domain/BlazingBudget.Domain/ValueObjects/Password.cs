using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    public class Password : Abp.Domain.Values.ValueObject
    {
        public string Value { get; private set; }

        private Password() { }

        [JsonConstructor]
        private Password(string value)
        {
            Value = value;
        }

        public static IResult<Password> Create(string value)
        {
            if (Regex.Match(value, "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})").Success == false)
            {
                return Result.Failure<Password>("The password does not meet the required strength.");
            }

            return Result.Success(new Password(value));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
