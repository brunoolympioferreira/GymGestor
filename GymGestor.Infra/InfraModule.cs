using GymGestor.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymGestor.Infra;
public static class InfraModule
{
    public static void AddInfra(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("CS_SQLSERVER_LOCALHOST_GYM_GESTOR") ?? throw new NullReferenceException();

        AddDb(services, connectionString);
    }

    private static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<GymGestorDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
