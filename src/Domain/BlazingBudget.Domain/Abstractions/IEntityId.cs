namespace BlazingBudget.Domain.Shared
{
    internal interface IEntityId<TPrimaryKey> where TPrimaryKey : struct
    {
        TPrimaryKey Value { get; }
    }
}
