using Mediator;
using System.Diagnostics.CodeAnalysis;

namespace BlazingBudget.Application.PipelineBehaviors;
public interface IValidate : IMessage
{
    bool IsValid([NotNullWhen(false)] out ValidationError? error);
}
