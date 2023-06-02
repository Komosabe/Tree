using Tree.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tree.Infrastructure.Seeders;
using Tree.Domain.Interfaces;
using Tree.Infrastructure.Repositories;

namespace Tree.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TreeDb");

        services.AddDbContext<TreeDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<TreeSeeder>();

        services.AddScoped<ITreeRepository, TreeRepository>();
    }
}
