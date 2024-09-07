using BlazingBudget.Domain.Shared;
using StronglyTypedIds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    /// <summary>
    /// Try Ulid https://github.com/Cysharp/Ulid
    /// </summary>
    [StronglyTypedId]
    public partial struct BudgetId { }
}
