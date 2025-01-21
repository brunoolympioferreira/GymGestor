using GymGestor.Application.Services.User.ReadOnly;
using GymGestor.Application.Services.User.WriteOnly.Create;
using GymGestor.Application.Services.User.WriteOnly.Update;
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
            .AddScoped<ICreateUserService, CreateUserService>()
            .AddScoped<IUserReadOnlyService, UserReadOnlyService>()
            .AddScoped<IUpdateUserService, UpdateUserService>();
    }
}
