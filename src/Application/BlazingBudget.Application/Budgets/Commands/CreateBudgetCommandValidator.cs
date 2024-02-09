using FluentValidation;

namespace BlazingBudget.Application.Budgets.Commands
{
    public class CreateBudgetCommandValidator : AbstractValidator<CreateBudgetCommand>
    {
        public CreateBudgetCommandValidator()
        {
            RuleFor(model => model.Name)
                .MaximumLength(300)
                .NotEmpty();
        }
    }
}
