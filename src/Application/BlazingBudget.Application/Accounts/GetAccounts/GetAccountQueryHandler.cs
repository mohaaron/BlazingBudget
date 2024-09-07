using BlazingBudget.Application.Accounts.Models;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Accounts.GetAccounts;
internal class GetAccountQueryHandler : IQueryHandler<GetAccountRequest, UpsertAccount>
{
    private readonly IMediator mediator;

    public GetAccountQueryHandler(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async ValueTask<UpsertAccount> Handle(GetAccountRequest query, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new UpsertAccount());
    }
}
