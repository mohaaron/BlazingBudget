using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System.Text.Json;

namespace BlazingBudget.Domain.Tests
{
    public class DebtTests
    {
        [Fact]
        public void Serializes_Debt_Aggregate_Successfully()
        {
            Result<Money> amountResult = Money.Create(0);

            if (amountResult.IsFailure)
            {
                throw new Exception(amountResult.Error);
            }

            Result<Debt> debtResult = Debt.Create("", amountResult.Value);
            if (debtResult.IsFailure)
            {
                throw new Exception(debtResult.Error);
            }

            var serialized = JsonSerializer.Serialize(debtResult.Value);
            var expectedAccount = JsonSerializer.Deserialize<Debt>(serialized);

            Assert.Equivalent(expectedAccount, debtResult.Value);
        }
    }
}