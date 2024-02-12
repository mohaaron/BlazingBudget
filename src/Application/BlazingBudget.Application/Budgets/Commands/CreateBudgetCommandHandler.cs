using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Application.Budgets.Commands
{
    public class CreateBudgetCommandHandler
    {
        public CreateBudgetCommandHandler() { }

        //[UnitOfWork] // From Abp library
        public Task Handle(CreateBudgetCommand request)
        {
            // TODO: Use Domain models for write only dbcontext

            // var aggregate = await repository.Get(model.Id);
            Budget budget = Budget.Create(AccountId.Create(), "My new budget", new DateOnly(2024, 1, 1));
            
            //budget.AddIncome(Income.Create("Salary", Money.Create(1).Value, new DateOnly(2024, 1, 1)));
            //budget.AddExpense(Expense.Create("Rent", Money.Create(1).Value));

            // aggregate.DoSomething(params ...);
            // aggregate.DoSomethingElse(params ...);
            // dispatcher.Dispatch(aggregate.DomainEvents); // Dispatch the events that were added in the mutations
            // unitOfWork.Commit()
            return Task.CompletedTask;
        }
    }
}
