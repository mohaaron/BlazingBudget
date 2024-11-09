namespace BlazingBudget.Application.Budgets.UpsertBudgets
{
    public class UpsertBudget
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
    }
}
