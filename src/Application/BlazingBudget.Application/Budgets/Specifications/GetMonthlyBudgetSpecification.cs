using BlazingBudget.Domain.Aggregates.Budgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budgets.Specifications;
/// <summary>
/// https://medium.com/@michaelmaurice410/implementing-the-specification-pattern-in-c-with-entity-framework-core-bac5d8522480
/// </summary>
public class GetMonthlyBudgetSpecification : SpecificationBase<Budget>
{
    public GetMonthlyBudgetSpecification(DateOnly month)
        : base(b => b.Month == month)
    {
        AddInclude(b => b.Incomes);
        AddInclude(b => b.Expenses);
    }

    
}
