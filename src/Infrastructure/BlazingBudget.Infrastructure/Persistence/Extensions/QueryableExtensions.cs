using System.Linq.Expressions;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.Extensions;

/// <summary>
/// Extension methods for IQueryable to return Maybe&lt;T&gt; instead of nullable types.
/// Enables functional-style handling of optional query results.
/// </summary>
public static class QueryableExtensions
{
	/// <summary>
	/// Returns the first element matching the predicate as Maybe&lt;T&gt;.
	/// Returns Maybe.None if no element is found.
	/// </summary>
	public static async Task<Maybe<TEntity>> FirstOrMaybeAsync<TEntity>(
		this IQueryable<TEntity> queryable,
		Expression<Func<TEntity, bool>> predicate,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
		return Maybe.From(entity);
	}

	/// <summary>
	/// Returns the first element as Maybe&lt;T&gt;.
	/// Returns Maybe.None if the sequence is empty.
	/// </summary>
	public static async Task<Maybe<TEntity>> FirstOrMaybeAsync<TEntity>(
		this IQueryable<TEntity> queryable,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await queryable.FirstOrDefaultAsync(cancellationToken);
		return Maybe.From(entity);
	}

	/// <summary>
	/// Returns the single element matching the predicate as Maybe&lt;T&gt;.
	/// Returns Maybe.None if no element is found.
	/// Throws if more than one element matches.
	/// </summary>
	public static async Task<Maybe<TEntity>> SingleOrMaybeAsync<TEntity>(
		this IQueryable<TEntity> queryable,
		Expression<Func<TEntity, bool>> predicate,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await queryable.SingleOrDefaultAsync(predicate, cancellationToken);
		return Maybe.From(entity);
	}

	/// <summary>
	/// Returns the single element as Maybe&lt;T&gt;.
	/// Returns Maybe.None if the sequence is empty.
	/// Throws if more than one element exists.
	/// </summary>
	public static async Task<Maybe<TEntity>> SingleOrMaybeAsync<TEntity>(
		this IQueryable<TEntity> queryable,
		CancellationToken cancellationToken = default)
		where TEntity : class
	{
		var entity = await queryable.SingleOrDefaultAsync(cancellationToken);
		return Maybe.From(entity);
	}
}
