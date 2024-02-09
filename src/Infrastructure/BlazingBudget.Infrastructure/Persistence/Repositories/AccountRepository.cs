using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure.Persistence.Repositories
{
    internal sealed class AccountRepository : IAccountRepository
    {
        private readonly BudgetContext context;

        public AccountRepository(BudgetContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IResult<bool>> CanCreateAccount(Account account)
        {
            var currentAccount = await context.FindAsync<Account>(account.Id.Value);

            if (currentAccount == null)
            {
                return Result.Success(true);
            }

            return Result.Failure<bool>("Account already exists.");
        }
    }
}
