using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Domain.ValueObjects;
using System.Text.Json;

namespace BlazingBudget.Domain.Tests
{
    public class DebtTests
    {
        [Fact]
        public void Serializes_Debt_Aggregate_Successfully()
        {
            Debt actualAccount = Debt.Create("Name of debt", Money.Create(1).Value).Value;

            var serialized = JsonSerializer.Serialize(actualAccount);
            var expectedAccount = JsonSerializer.Deserialize<Debt>(serialized);

            Assert.Equivalent(expectedAccount, actualAccount);
        }
    }
}