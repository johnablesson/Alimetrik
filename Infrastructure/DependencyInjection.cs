using Abstractions.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<InstallmentServiceDbContext>(options => options.UseInMemoryDatabase(databaseName: "PaymentPlanDb"));
        services.AddScoped<IInstallmentServiceDbContext>(implementationFactory: provider => provider.GetService<InstallmentServiceDbContext>() ?? throw new Exception("Error getting db context"));
    }
}
