using GymGestor.Application.Services.Account;
using GymGestor.Application.Services.Member.Create;
using GymGestor.Application.Services.User.ReadOnly;
using GymGestor.Application.Services.User.WriteOnly.Create;
using GymGestor.Application.Services.User.WriteOnly.Delete;
using GymGestor.Application.Services.User.WriteOnly.Update;
using Microsoft.Extensions.DependencyInjection;

namespace GymGestor.Application;
public static class ApplicatonModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services
            .AddUserServices()
            .AddAccountServices()
            .AddMemberServices();
    }

    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ICreateUserService, CreateUserService>()
            .AddScoped<IUserReadOnlyService, UserReadOnlyService>()
            .AddScoped<IUpdateUserService, UpdateUserService>()
            .AddScoped<IRemoveUserService, RemoveUserService>();
    }

    public static IServiceCollection AddAccountServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ILoginService, LoginService>();
    }

    public static IServiceCollection AddMemberServices(this IServiceCollection services)
    {
        return services
            .AddScoped<ICreateMemberService, CreateMemberService>();
    }
}
