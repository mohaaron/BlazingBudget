using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budget
{
    public record ExpenseId(Guid Value) : IEntityId<Guid>;
}
