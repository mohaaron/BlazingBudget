using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueObjects;
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using CSharpFunctionalExtensions;
using Mediator;

namespace BlazingBudget.Application.Budgets.UpsertBudgets;
public class UpsertBudgetHandler : ICommandHandler<UpsertBudgetRequest, IResult>
{
	private readonly BudgetContext budgetContext;

	public UpsertBudgetHandler(BudgetContext budgetContext)
	{
		this.budgetContext = budgetContext;
	}

	public async ValueTask<IResult> Handle(UpsertBudgetRequest command, CancellationToken cancellationToken)
	{
		// TODO: Use Domain models for write only dbcontext
		Result<Budget, Exception> result = await budgetContext.Budgets.FindAsync(command.Budget.Id, cancellationToken)
			.ToResultAsync(new Exception());

		if (result.TryGetError(out Exception? error))
		{
			return Result.Failure<IResult>(error.Message);
		}

		Maybe<Budget> maybeBudget = await budgetContext.Budgets.FindAsync(command.Budget.Id);
		if (maybeBudget.HasValue)
		{

		}

		// var aggregate = await repository.Get(model.Id);
		Budget budget = Budget.Create(AccountId.Create(), "My new budget", new DateOnly(2024, 1, 1));

		//budget.AddIncome(Income.Create("Salary", Money.Create(1).Value, new DateOnly(2024, 1, 1)));
		budget.AddExpense(Expense.Create("Rent", Money.Create(1).Value));

		// aggregate.DoSomething(params ...);
		// aggregate.DoSomethingElse(params ...);
		// dispatcher.Dispatch(aggregate.DomainEvents); // Dispatch the events that were added in the mutations
		// unitOfWork.Commit()

		return Result.Success();
	}
}
