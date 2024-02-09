using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Debts
{
    internal class DebtPaymentCreatedEvent
    {
        public DebtId DebtId { get; set; }
        public PaymentId PaymentId { get; set; }
        public Money AmountPaid { get; set; }
    }
}
