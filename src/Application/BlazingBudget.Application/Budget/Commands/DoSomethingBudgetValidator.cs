using FluentValidation;

namespace BlazingBudget.Application.Budget.Commands
{
    public class DoSomethingBudgetValidator : AbstractValidator<DoSomethingBudget>
    {
        public DoSomethingBudgetValidator()
        {
            RuleFor(model => model.Name)
                .MaximumLength(300)
                .NotEmpty();
        }
    }
}
