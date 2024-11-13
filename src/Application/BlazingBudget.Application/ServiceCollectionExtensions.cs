using BlazingBudget.Application.PipelineBehaviors;
using FastEndpoints;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingBudget.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
		services.AddFastEndpoints();

		services.AddMediator(
            options =>
            {
                options.ServiceLifetime = ServiceLifetime.Scoped;
            }
        );
        return services
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorLoggingBehaviour<,>))
            .AddSingleton(typeof(IPipelineBehavior<,>), typeof(MessageValidatorBehaviour<,>));
    }
}
