using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Accounts;
public sealed class Account : Entity<AccountId>
{
	public PersonName Name { get; private set; }

	public Email Email { get; private set; }

	public Password Password { get; private set; }

	private Account() { }

	[JsonConstructor]
	private Account(AccountId id, PersonName name, Email email, Password password)
	{
		Id = id;
		Name = name;
		Email = email;
		Password = password;

		//DomainEvents.Add(new AccountCreatedEvent(Id));
	}

	public static Result<Account> Create(PersonName name, Email email, Password password)
		=> Result.Success(new Account(new AccountId(Guid.NewGuid()), name, email, password));
}
