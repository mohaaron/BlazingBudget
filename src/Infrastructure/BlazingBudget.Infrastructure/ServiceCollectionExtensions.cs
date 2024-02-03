using BlazingBudget.Domain.Aggregates.Account;
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using BlazingBudget.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContextFactory<BudgetContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableDetailedErrors(true);
            });

            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
