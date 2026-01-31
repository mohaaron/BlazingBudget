using BlazingBudget.Domain.Aggregates.Debts;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework;
// https://github.com/andrewlock/StronglyTypedId/issues/97#issuecomment-1807079753
internal class DbContextConventions : DbContext
{
	public DbContextConventions(DbContextOptions options) : base(options)
	{
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		// Always use the converter any time xxxId is used
		//configurationBuilder.Properties<DebtId>().HaveConversion<DebtId.EfCoreValueConverter>();
	}
}
