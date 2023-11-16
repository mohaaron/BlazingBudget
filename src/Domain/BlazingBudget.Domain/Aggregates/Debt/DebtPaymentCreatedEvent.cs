using BlazingBudget.Domain.Aggregates.Budget;
using BlazingBudget.Domain.Aggregates.Debt;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Debt
{
    internal class DebtPaymentCreatedEvent
    {
        public DebtId DebtId { get; set; }
        public PaymentId PaymentId { get; set; }
        public Money AmountPaid { get; set; }
    }
}
