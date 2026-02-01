using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects;
public class PersonName : ValueObject
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

	public static Result<PersonName> Create(string firstName, string lastName) => firstName == null || lastName == null
			? Result.Failure<PersonName>("First name and last name are required.")
			: firstName.Length > MaxLength
			? Result.Failure<PersonName>("First name must be less than 300 charactors.")
			: lastName.Length > MaxLength
			? Result.Failure<PersonName>("Last name must be less than 300 charactors.")
			: Result.Success(new PersonName(firstName, lastName));


	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return FirstName;
		yield return LastName;
	}
}
