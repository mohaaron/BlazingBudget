using BlazingBudget.Domain.Aggregates.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure.Persistence.Repositories
{
    public sealed class AccountRepository : IAccountRepository
    {
        public Task<bool> IsExistingAccountAsync(Account account)
        {
            // var currentAccount = await context.FindAsync(account.Id);

            if (account.Id == account.Id)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
