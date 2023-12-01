using CSharpFunctionalExtensions;

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
            var accountExistsResult = await _accountRepository.CanCreateAccount(account);
            if (accountExistsResult.Value)
            {
                return AccountResults.AccountExists;
            }

            return Result.Success(true);
        }
    }
}
