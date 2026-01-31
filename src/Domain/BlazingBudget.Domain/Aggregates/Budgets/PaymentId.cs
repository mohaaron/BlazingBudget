using StronglyTypedIds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Aggregates.Budgets;
/// <summary>
/// Payment unique identifier.
/// </summary>
[StronglyTypedId]
public readonly partial struct PaymentId { }
