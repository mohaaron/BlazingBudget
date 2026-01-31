using BlazingBudget.Domain.Abstractions;

namespace BlazingBudget.Domain.Aggregates.Accounts;
public record AccountCreatedEvent(AccountId AccountId) : IDomainEvent
{
	public DateTime EventTime { get; set; }
	public object EventSource { get; set; } = default!;
}
