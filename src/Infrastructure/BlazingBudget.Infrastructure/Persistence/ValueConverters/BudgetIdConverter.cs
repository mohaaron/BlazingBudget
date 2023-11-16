using BlazingBudget.Domain.Aggregates.Budget;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.ValueConverters
{
    /// <summary>
    /// https://community.abp.io/posts/value-generation-for-ddd-guarded-types-with-entity-framework-core-7.0-ll9qg37b
    /// </summary>
    public class BudgetIdConverter : ValueConverter<BudgetId, Guid>
    {
        BudgetIdConverter() : base(v => v.Value, v => new(v))
        {}
    }
}
