using BlazingBudget.Domain.Aggregates.Budget;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
