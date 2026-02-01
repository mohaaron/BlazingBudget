using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.Aggregates.Debts;
using BlazingBudget.Domain.Aggregates.Expenses;
using BlazingBudget.Domain.Aggregates.Incomes;
using BlazingBudget.Domain.Aggregates.Payments;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazingBudget.Infrastructure.Persistence.ValueConverters;

/// <summary>
/// EF Core value converters for strongly-typed IDs.
/// </summary>
public class BudgetIdConverter : ValueConverter<BudgetId, Guid>
{
	public BudgetIdConverter() : base(v => v.Value, v => new BudgetId(v)) { }
}

public class ExpenseIdConverter : ValueConverter<ExpenseId, Guid>
{
	public ExpenseIdConverter() : base(v => v.Value, v => new ExpenseId(v)) { }
}

public class IncomeIdConverter : ValueConverter<IncomeId, Guid>
{
	public IncomeIdConverter() : base(v => v.Value, v => new IncomeId(v)) { }
}

public class PaymentIdConverter : ValueConverter<PaymentId, Guid>
{
	public PaymentIdConverter() : base(v => v.Value, v => new PaymentId(v)) { }
}

public class AccountIdConverter : ValueConverter<AccountId, Guid>
{
	public AccountIdConverter() : base(v => v.Value, v => new AccountId(v)) { }
}

public class DebtIdConverter : ValueConverter<DebtId, Guid>
{
	public DebtIdConverter() : base(v => v.Value, v => new DebtId(v)) { }
}

public class DebtPaymentIdConverter : ValueConverter<DebtPaymentId, Guid>
{
	public DebtPaymentIdConverter() : base(v => v.Value, v => new DebtPaymentId(v)) { }
}
