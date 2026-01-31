//using BlazingBudget.Domain.Aggregates.Accounts;
//using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using BlazingBudget.Application.ViewModels.Budgets;
using BlazingBudget.Domain.Aggregates.Accounts;
using FastEndpoints;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlazingBudget.Application.Budgets.ApiEndpoints;
public class GetBudgetsEndpoint : Endpoint<GetBudgetsRequest, IReadOnlyCollection<Budget>>
{
	private readonly BudgetContext context;

	public GetBudgetsEndpoint(BudgetContext context)
	{
		this.context = context;
	}

	public override void Configure()
	{
		Get("budgets");
		AllowAnonymous();
	}

	public override async Task HandleAsync(GetBudgetsRequest req, CancellationToken ct)
	{
		Logger.LogInformation("Getting budgets for account {AccountId}", req);

		Budget[] budgets = await context.Budgets
			.Where(e => e.AccountId == AccountId.Create())
			.ProjectToType<Budget>()
			.ToArrayAsync(ct);

		await SendAsync(budgets, (int)HttpStatusCode.OK, ct);
	}
}
