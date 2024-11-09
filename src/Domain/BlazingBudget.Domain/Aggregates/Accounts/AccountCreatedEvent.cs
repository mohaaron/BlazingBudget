using BlazingBudget.Domain.Abstractions;

namespace BlazingBudget.Domain.Aggregates.Accounts;
public record AccountCreatedEvent(AccountId AccountId) : IDomainEvent
{
    public DateTime EventTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public object EventSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
