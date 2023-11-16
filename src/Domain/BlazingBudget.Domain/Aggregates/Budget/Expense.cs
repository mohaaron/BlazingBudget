using Abp;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Budget
{
    public class Expense : Entity<ExpenseId>
    {
        private Expense() { }

        private Expense(ExpenseId id, string name, Money cost)
        {
            Id = id;
            ChangeName(name);
            Cost = cost;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = CreatedOn;
        }

        public static Expense Create(string name, Money cost)
        {
            return new Expense(new ExpenseId(Guid.NewGuid()), name, cost);
        }

        public string Name { get; private set; }

        public Money Cost { get; private set; }

        public string Notes { get; private set; } // How do we model optional attributes?

        private ICollection<Payment> payments { get; set; }

        internal Expense ChangeName(string name)
        {
            SetName(name);
            return this;
        }

        private void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        internal void MakePayment(Payment payment)
        {
            payments.Add(payment);
        }
    }
}
