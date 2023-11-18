using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    public class PersonName : Abp.Domain.Values.ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";

        public static readonly int MaxLength = 300;
        
        private PersonName() { }

        [JsonConstructor]
        private PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public static IResult<PersonName> Create(string firstName, string lastName)
        {
            if (firstName == null || lastName == null)
            {
                return Result.Failure<PersonName>("First name and last name are required.");
            }

            if (firstName.Length > MaxLength)
            {
                return Result.Failure<PersonName>("First name must be less than 300 charactors.");
            }

            if (lastName.Length > MaxLength)
            {
                return Result.Failure<PersonName>("Last name must be less than 300 charactors.");
            }

            return Result.Success(new PersonName(firstName, lastName));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
