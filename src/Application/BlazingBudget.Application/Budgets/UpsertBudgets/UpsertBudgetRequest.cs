using CSharpFunctionalExtensions;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budgets.UpsertBudgets;
public readonly struct UpsertBudgetRequest : ICommand<IResult>
{
	public UpsertBudget Budget { get; }

	public UpsertBudgetRequest(UpsertBudget budget)
	{
		Budget = budget;
	}
}