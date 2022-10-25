using Abstractions.Persistence;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class InstallmentServiceDbContext : DbContext, IInstallmentServiceDbContext
{
    protected readonly IConfiguration Configuration;

    public InstallmentServiceDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstallmentConfiguration).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        // options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        options.UseInMemoryDatabase(databaseName: "PaymentPlanDb");
    }

    public DbSet<Installment> Installments { get; set; }
    public DbSet<PaymentPlan> PaymentPlans { get; set; }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await SaveChangesAsync(cancellationToken);
    }
}