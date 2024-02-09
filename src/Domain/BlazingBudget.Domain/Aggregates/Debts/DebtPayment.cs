using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Debts
{

    public class DebtPayment : Entity<DebtPaymentId>
    {
        private DebtPayment() { }

        [JsonConstructor]
        private DebtPayment(DebtPaymentId id, Money amount, string notes)
        {
            Id = id;
            Amount = amount;
            Notes = notes;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = CreatedOn;
        }

        public static DebtPayment Create(Money amount, string notes = "")
        {
            return new DebtPayment(DebtPaymentId.New(), amount, notes);
        }

        public Money Amount { get; private set; }

        public string Notes { get; set; } = string.Empty;
    }
}
