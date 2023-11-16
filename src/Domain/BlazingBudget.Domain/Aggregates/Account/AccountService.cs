using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    public sealed class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IResult<bool>> CanCreateAccount(Account account)
        {
            // Check db that account doesn't already exist.
            if (await _accountRepository.IsExistingAccountAsync(account))
            {
                return AccountResults.AccountExists;
            }

            return Result.Success(true);
        }
    }
}
