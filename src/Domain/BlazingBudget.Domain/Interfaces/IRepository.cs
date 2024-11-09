using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.Interfaces;
public interface IRepository<T> //where T : IAggregateRoot<T>
{
	IMaybe<T> Get(Guid id);

	IResult Upsert(T aggregate);

	IResult Delete(Guid id);
}
