using GymGestor.Application.Services.User.WriteOnly;
using Microsoft.Extensions.DependencyInjection;

namespace GymGestor.Application;
public static class ApplicatonModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddUserServices();
    }

    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserWriteOnlyService, UserWriteOnlyService>();
    }
}
