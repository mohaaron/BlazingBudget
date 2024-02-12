using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Accounts
{
    public interface IAccountRepository
    {
        Task<Result<bool>> CanCreateAccount(Account account);
    }
}
