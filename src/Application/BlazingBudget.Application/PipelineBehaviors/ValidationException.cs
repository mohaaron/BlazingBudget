using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Application.PipelineBehaviors;
public sealed class ValidationException : Exception
{
    public ValidationException(ValidationError validationError) : base("Validation error") =>
        ValidationError = validationError;

    public ValidationError ValidationError { get; }
}
