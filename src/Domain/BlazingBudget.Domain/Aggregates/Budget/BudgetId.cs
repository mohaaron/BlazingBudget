using BlazingBudget.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budget
{
    /// <summary>
    /// BudgetId 
    /// </summary>
    /// <param name="Value"></param>
    public record struct BudgetId(Guid Value) : IEntityId<Guid>;
}
