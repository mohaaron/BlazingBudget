using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.Extensions;

/// <summary>
/// Extension methods for DbSet to return Maybe&lt;T&gt; instead of nullable types.
/// Enables functional-style handling of optional query results.
/// </summary>
public static class DbSetExtensions
{
	/// <summary>
	/// Finds an entity by its primary key and returns Maybe&lt;T&gt;.
	/// Returns Maybe.None if the entity is not found.
	/// </summary>
	public static async Task<Maybe<TEntity>> FindMaybeAsync<TEntity>(
		this DbSet<TEntity> dbSet,
		object keyValue,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await dbSet.FindAsync([keyValue], cancellationToken);
		return Maybe.From(entity);
	}

	/// <summary>
	/// Finds an entity by composite primary key and returns Maybe&lt;T&gt;.
	/// Returns Maybe.None if the entity is not found.
	/// </summary>
	public static async Task<Maybe<TEntity>> FindMaybeAsync<TEntity>(
		this DbSet<TEntity> dbSet,
		object[] keyValues,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await dbSet.FindAsync(keyValues, cancellationToken);
		return Maybe.From(entity);
	}
}
