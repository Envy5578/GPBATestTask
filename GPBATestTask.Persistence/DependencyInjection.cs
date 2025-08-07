using GPBATestTask.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GPBATestTask.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {       
        var connetionString = configuration.GetConnectionString("PgSql");

        services.AddDbContext<GPBATestTaskDbContext>(options =>
        {
            options.UseNpgsql(connetionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IGPBATestTaskDbContext>(provider => provider.GetService<GPBATestTaskDbContext>());

        return services;
    }
}