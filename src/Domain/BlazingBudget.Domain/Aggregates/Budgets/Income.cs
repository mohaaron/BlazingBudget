using Abp;
using BlazingBudget.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    /// <summary>
    /// {BudgetPlan}Income is an entity because the amount of a payment over time affects long term finances.
    /// </summary>
    public class Income : Entity<IncomeId>
    {
        private Income() { }

        private Income(IncomeId id, string source, Money amount, DateOnly payDate)
        {
            Id = id;
            Source = Check.NotNullOrWhiteSpace(source, nameof(source));
            Amount = amount;
            PayDate = payDate;
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = CreatedOn;
        }

        public static Income Create(string source, Money amount, DateOnly payDate)
        {
            return new Income(new IncomeId(Guid.NewGuid()), source, amount, payDate);
        }

        public string Source { get; private set; }

        public Money Amount { get; private set; }

        public DateOnly PayDate { get; private set; }

        public string Notes { get; private set; } // How do we model optional attributes?
    }
}

