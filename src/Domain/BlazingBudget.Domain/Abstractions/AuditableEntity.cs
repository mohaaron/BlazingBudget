
namespace BlazingBudget.Domain.Abstractions;
/// <summary>
/// Base class for entities with audit properties
/// </summary>
/// <typeparam name="TEntityId"></typeparam>
public abstract class AuditableEntity<TEntityId> : CSharpFunctionalExtensions.Entity<TEntityId> where TEntityId : IComparable<TEntityId>
{
	// TODO: Move audit properties to interface
	public DateTime CreatedOn { get; protected set; }
	public DateTime ModifiedOn { get; protected set; }
}
