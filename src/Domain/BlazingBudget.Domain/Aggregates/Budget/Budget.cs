using Abp;
using Abp.Domain.Entities;
using Ardalis.GuardClauses;
using BlazingBudget.Domain.Aggregates.Account;

namespace BlazingBudget.Domain.Aggregates.Budget
{
    public sealed class Budget : AggregateRoot<BudgetId>
    {
        private Budget() { }

        private Budget(BudgetId budgetId, AccountId accountId, string name, DateOnly month)
        {
            Id = budgetId;

            AccountId = accountId;

            // Also must not already exist
            BudgetName = Check.NotNullOrWhiteSpace(name, nameof(name));

            // Also must not already exist
            Month = Guard.Against.InvalidInput(month, nameof(month),
                month => month >= DateOnly.FromDateTime(DateTime.Now));
        }

        public static Budget Create(AccountId accountId, string name, DateOnly month)
        {
            return new Budget(new BudgetId(Guid.NewGuid()), accountId, name, month);
        }

        public AccountId AccountId { get; private set; }

        public string BudgetName { get; private set; }

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
