using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Infrastructure.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework;
/// <summary>
/// 
/// </summary>
public sealed class BudgetContext : DbContext//, IBudgetContext
{
	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		configurationBuilder.Properties<BudgetId>().HaveConversion<BudgetIdConverter>();
		configurationBuilder.Properties<ExpenseId>().HaveConversion<BudgetIdConverter>();
	}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Budget> Budgets { get; set; }
	public DbSet<Expense> Expenses { get; set; }
	public DbSet<Income> Incomes { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Debt> Debts { get; set; }
}
