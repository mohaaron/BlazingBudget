using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Domain.Aggregates.Expenses;
using BlazingBudget.Domain.Aggregates.Incomes;
using BlazingBudget.Domain.Aggregates.Payments;
using Mapster;

namespace BlazingBudget.Application.Mapping;

/// <summary>
/// Configures Mapster type adapters for strongly-typed IDs and other custom mappings.
/// </summary>
public static class MapsterConfiguration
{
	/// <summary>
	/// Registers all custom type mappings. Call this at application startup.
	/// </summary>
	public static void Configure()
	{
		ConfigureStronglyTypedIds();
	}

	private static void ConfigureStronglyTypedIds()
	{
		// BudgetId <-> Guid
		TypeAdapterConfig<BudgetId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, BudgetId>.NewConfig()
			.MapWith(src => new BudgetId(src));

		// AccountId <-> Guid
		TypeAdapterConfig<AccountId, Guid>.NewConfig()
			.MapWith(src => src.Value);

		// ExpenseId <-> Guid
		TypeAdapterConfig<ExpenseId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, ExpenseId>.NewConfig()
			.MapWith(src => new ExpenseId(src));

		// IncomeId <-> Guid
		TypeAdapterConfig<IncomeId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, IncomeId>.NewConfig()
			.MapWith(src => new IncomeId(src));

		// PaymentId <-> Guid
		TypeAdapterConfig<PaymentId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, PaymentId>.NewConfig()
			.MapWith(src => new PaymentId(src));

		// DebtId <-> Guid
		TypeAdapterConfig<DebtId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, DebtId>.NewConfig()
			.MapWith(src => new DebtId(src));

		// DebtPaymentId <-> Guid
		TypeAdapterConfig<DebtPaymentId, Guid>.NewConfig()
			.MapWith(src => src.Value);
		TypeAdapterConfig<Guid, DebtPaymentId>.NewConfig()
			.MapWith(src => new DebtPaymentId(src));
	}
}
