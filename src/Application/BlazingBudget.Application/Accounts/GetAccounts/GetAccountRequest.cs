using BlazingBudget.Application.Accounts.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Accounts.GetAccounts;
internal class GetAccountRequest : IQuery<UpsertAccount>
{
    public Guid AccountId { get; set; }
}
