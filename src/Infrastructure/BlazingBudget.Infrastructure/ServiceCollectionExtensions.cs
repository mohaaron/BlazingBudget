using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Infrastructure.Persistence.EntityFramework;
using BlazingBudget.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingBudget.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContextFactory<BudgetContext>(options =>
            {
                string fileName = @"\blazingbudget.db";
                string dbFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + fileName;
                options
                .UseSqlite($"Data Source={dbFilePath}", x => x.MigrationsAssembly("BlazingBudget.Infrastructure"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableDetailedErrors(true);
            });

            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
