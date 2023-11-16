using BlazingBudget.Domain.Aggregates.Debt;
using BlazingBudget.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure.Persistence.DbContexts
{
    // https://github.com/andrewlock/StronglyTypedId/issues/97#issuecomment-1807079753
    internal class DbContextConventions : DbContext
    {
        public DbContextConventions(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder
            //.Properties<DebtId>()
            //    .HaveConversion<DebtId.EfCoreValueConverter>();  // Always use the converter any time xxxId is used
        }
    }
}
