using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.PipelineBehaviors;
public sealed record ValidationError(IEnumerable<string> Errors);
