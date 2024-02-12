using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budgets.Queries
{
    internal class GetBudgetQueryHandler
    {
        public Task Handle(GetBudgetQuery query)
        {
            // TODO: Use read only  db model for read only dbcontext because the 
            // readonly model has navigation properties which domain models don't have.

            // Map db entity to model
            return Task.CompletedTask;
        }
    }
}
