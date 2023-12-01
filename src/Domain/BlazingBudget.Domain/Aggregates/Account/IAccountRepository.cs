using BlazingBudget.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    public interface IAccountRepository
    {
        Task<IResult<bool>> CanCreateAccount(Account account);
    }
}
