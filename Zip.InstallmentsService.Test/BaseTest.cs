using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Zip.InstallmentsService.Test;

public class BaseTest
{
    protected IServiceCollection _services;
    protected IServiceProvider _serviceProvider;
    protected InstallmentServiceDbContext _context;

    public BaseTest()
    {
        SetupDI();
    }

    protected void SetupDI()
    {
        var configuration = new ConfigurationBuilder().Build();
        _services = new ServiceCollection();
        _services.AddSingleton<IConfiguration>(configuration);
        _services.AddInfrastructure();
        _services.AddApplication();

        _serviceProvider = _services.BuildServiceProvider();
        _context = _serviceProvider.GetService<InstallmentServiceDbContext>();
        _context.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
    }
}
