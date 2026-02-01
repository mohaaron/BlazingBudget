using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Domain.Aggregates.Expenses;
using BlazingBudget.Domain.Aggregates.Incomes;
using BlazingBudget.Domain.Aggregates.Payments;
using BlazingBudget.Domain.ValueObjects;
using BlazingBudget.Infrastructure.Persistence.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework;
/// <summary>
/// EF Core DbContext for BlazingBudget application.
/// Uses SQLite database stored in AppData folder.
/// </summary>
public sealed class BudgetContext : DbContext
{
	public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
	{
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		// Configure value converters for all strongly-typed IDs
		configurationBuilder.Properties<BudgetId>().HaveConversion<BudgetIdConverter>();
		configurationBuilder.Properties<ExpenseId>().HaveConversion<ExpenseIdConverter>();
		configurationBuilder.Properties<IncomeId>().HaveConversion<IncomeIdConverter>();
		configurationBuilder.Properties<PaymentId>().HaveConversion<PaymentIdConverter>();
		configurationBuilder.Properties<AccountId>().HaveConversion<AccountIdConverter>();
		configurationBuilder.Properties<DebtId>().HaveConversion<DebtIdConverter>();
		configurationBuilder.Properties<DebtPaymentId>().HaveConversion<DebtPaymentIdConverter>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Configure Money as an owned type (value object)
		modelBuilder.Entity<Expense>().OwnsOne(e => e.Cost, money =>
		{
			money.Property(m => m.Value).HasColumnName("Cost");
			money.OwnsOne(m => m.Currency, currency =>
			{
				currency.Property(c => c.Name).HasColumnName("CurrencyName");
				currency.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
			});
		});

		modelBuilder.Entity<Income>().OwnsOne(i => i.Amount, money =>
		{
			money.Property(m => m.Value).HasColumnName("Amount");
			money.OwnsOne(m => m.Currency, currency =>
			{
				currency.Property(c => c.Name).HasColumnName("CurrencyName");
				currency.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
			});
		});

		modelBuilder.Entity<Payment>().OwnsOne(p => p.Amount, money =>
		{
			money.Property(m => m.Value).HasColumnName("Amount");
			money.OwnsOne(m => m.Currency, currency =>
			{
				currency.Property(c => c.Name).HasColumnName("CurrencyName");
				currency.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
			});
		});

		modelBuilder.Entity<Debt>().OwnsOne(d => d.Total, money =>
		{
			money.Property(m => m.Value).HasColumnName("TotalAmount");
			money.OwnsOne(m => m.Currency, currency =>
			{
				currency.Property(c => c.Name).HasColumnName("CurrencyName");
				currency.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
			});
		});

		modelBuilder.Entity<DebtPayment>().OwnsOne(dp => dp.Amount, money =>
		{
			money.Property(m => m.Value).HasColumnName("Amount");
			money.OwnsOne(m => m.Currency, currency =>
			{
				currency.Property(c => c.Name).HasColumnName("CurrencyName");
				currency.Property(c => c.CurrencyCode).HasColumnName("CurrencyCode");
			});
		});

		// Configure Account value objects
		modelBuilder.Entity<Account>().OwnsOne(a => a.Name);
		modelBuilder.Entity<Account>().OwnsOne(a => a.Email);
		modelBuilder.Entity<Account>().OwnsOne(a => a.Password);
	}

	public DbSet<Account> Accounts { get; set; }
	public DbSet<Budget> Budgets { get; set; }
	public DbSet<Expense> Expenses { get; set; }
	public DbSet<Income> Incomes { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Debt> Debts { get; set; }
}
