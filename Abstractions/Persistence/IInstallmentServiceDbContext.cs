using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService;

namespace Abstractions.Persistence;

public interface IInstallmentServiceDbContext
{
    public DbSet<Installment> Installments { get; set; }
    public DbSet<PaymentPlan> PaymentPlans { get; set; }
    Task<int> Save(CancellationToken cancellationToken);
}