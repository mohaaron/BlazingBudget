using FluentValidation;

namespace BlazingBudget.Application.Budgets.UpsertBudgets
{
    public class UpsertBudgetValidator : AbstractValidator<UpsertBudget>
    {
        public UpsertBudgetValidator()
        {
            RuleFor(model => model.Name)
                .MaximumLength(300)
                .NotEmpty();
        }
    }
}
