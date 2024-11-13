using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Infrastructure.Persistence.EntityFramwork;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Infrastructure.Persistence.Repositories;
internal sealed class AccountRepository : IAccountRepository
{
    private readonly BudgetContext context;

    public AccountRepository(BudgetContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result<bool>> CanCreateAccount(Account account)
    {
        Result<Account, string> result = await context.Accounts.FindAsync(account.Id.Value)
			.ToResultAsync($"Error fetching account for id {account.Id.Value}.");

		return result.TryGetError(out string? error) ? Result.Failure<bool>(error) : Result.Success(true);
	}
}
