namespace Zip.InstallmentsService;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreatePaymentPlanCommand));
    }
}
