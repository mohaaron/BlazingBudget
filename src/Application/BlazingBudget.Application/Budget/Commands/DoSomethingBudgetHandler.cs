using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budget.Commands
{
    public class DoSomethingBudgetHandler
    {
        public DoSomethingBudgetHandler() { }

        //[UnitOfWork] // From Abp library
        public Task Handle(DoSomethingBudget model)
        {
            // var aggregate = await repository.Get(model.Id);
            // aggregate.DoSomething(params ...);
            // aggregate.DoSomethingElse(params ...);
            // dispatcher.Dispatch(aggregate.DomainEvents); // Dispatch the events that were added in the mutations
            // unitOfWork.Commit()
            return Task.CompletedTask;
        }
    }
}
