using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Budget
{
    /// <summary>
    /// {BudgetPlan}Payment is an entity because the amount of a payment over time affects long term finances.
    /// </summary>
    public class Payment : Entity<PaymentId>
    {
        private Payment() { }

        [JsonConstructor]
        private Payment(PaymentId id, Money amount, string notes)
        {
            Id = id;
            Amount = amount;
            Notes = notes;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = CreatedOn;
        }

        public static Payment Create(Money amount, string notes = "")
        {
            return new Payment(new PaymentId(Guid.NewGuid()), amount, notes);
        }

        public void ChangeAmount(Money amount)
        {
            Amount = amount;
        }

        public void ChangeNotes(string notes)
        {
            Notes = notes;
        }

        public Money Amount { get; private set; }

        public string Notes { get; set; } = string.Empty;
    }
}
