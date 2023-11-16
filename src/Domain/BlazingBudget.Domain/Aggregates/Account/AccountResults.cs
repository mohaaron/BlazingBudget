using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Account
{
    public static class AccountResults
    {
        public static readonly Result<bool> AccountExists = Result.Failure<bool>("Account already exists");
    }
}
