using Infrastructure.Persistence;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
        if (string.IsNullOrEmpty(connectionString))
        {
            System.Console.WriteLine(connectionString);

            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        // Guard.Against.Null(connectionString, message: "Connection string 'CleanArchitectureDb' not found.");

        // Регистрация DbContext
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("Infrastructure"));
            options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

        });

        // Регистрация репозиториев
        // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        // services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        //
        // // Регистрация UnitOfWork
        // services.AddScoped<IUnitOfWork, UnitOfWork>();

    }

}
