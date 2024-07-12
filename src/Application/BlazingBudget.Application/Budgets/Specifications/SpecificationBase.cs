using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.Budgets.Specifications;
public class SpecificationBase<TEntity> where TEntity : class
{
    public Expression<Func<TEntity, bool>> Criteria { get; }
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
    public Expression<Func<TEntity, object>> OrderBy { get; private set; } = default!;

    public SpecificationBase(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<TEntity, object>> include)
    {
        Includes.Add(include);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
    {
        OrderBy = orderBy;
    }
}
