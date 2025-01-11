using GymGestor.Core.Repositories;
using GymGestor.Infra.Persistence;
using GymGestor.Infra.Persistence.Repositories;
using GymGestor.Infra.Persistence.UnityOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymGestor.Infra;
public static class InfraModule
{
    public static void AddInfra(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("CS_SQLSERVER_LOCALHOST_GYM_GESTOR") ?? throw new NullReferenceException();

        services
            .AddDb(connectionString)
            .AddUnityOfWork()
            .AddRepositories();
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GymGestorDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services)
    {
        services
            .AddScoped<IUnityOfWork, UnityOfWork>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
