﻿using Abp;
using Abp.Domain.Entities;
using BlazingBudget.Domain.Aggregates.Accounts;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    public sealed class Budget : AggregateRoot<BudgetId>
    {
        private Budget() { }

        private Budget(BudgetId budgetId, AccountId accountId, string name, DateOnly month)
        {
            Id = budgetId;

            AccountId = accountId;

            // Also must not already exist
            //Name = Check.NotNullOrWhiteSpace(name, nameof(name));

            // Also must not already exist
            //Month = Guard.Against.InvalidInput(month, nameof(month),
            //    month => month >= DateOnly.FromDateTime(DateTime.Now));
        }

        public static Budget Create(AccountId accountId, string name, DateOnly month)
            => new(BudgetId.New(), accountId, name, month);

        public AccountId AccountId { get; private set; }

        public string Name { get; private set; }

        public DateOnly Month { get; private set; }

        public IReadOnlyCollection<Expense> Expenses => expenses;

        public IReadOnlyCollection<Income> Incomes => incomes;

        private HashSet<Expense> expenses = new HashSet<Expense>();

        private HashSet<Income> incomes = new HashSet<Income>();

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public void AddIncome(Income income)
        {
            incomes.Add(income);
        }
    }
}
