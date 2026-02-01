using BlazingBudget.Domain.Aggregates.Expenses;
using BlazingBudget.Domain.Aggregates.Payments;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    internal class ExpensePaymentCreated
    {
        public ExpenseId ExpenseId { get; set; }
        public PaymentId PaymentId { get; set; }
        public Money AmountPaid { get; set; } = Money.Create(0).Value;
    }
}
