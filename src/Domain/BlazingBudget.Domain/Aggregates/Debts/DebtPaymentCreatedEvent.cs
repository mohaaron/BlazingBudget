using BlazingBudget.Domain.Aggregates.Payments;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Debts
{
    internal class DebtPaymentCreatedEvent
    {
        public DebtId DebtId { get; set; }
        public PaymentId PaymentId { get; set; }
        public Money AmountPaid { get; set; }
    }
}
