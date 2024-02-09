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
            // Map db entity to model
            return Task.CompletedTask;
        }
    }
}
