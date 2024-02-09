using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    internal class ExpensePaymentCreated
    {
        public ExpenseId ExpenseId { get; set; }
        public PaymentId PaymentId { get; set; }
        public Money AmountPaid { get; set; } = Money.Create(0).Value;
    }
}
