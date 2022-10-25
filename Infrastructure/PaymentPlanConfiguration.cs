namespace Infrastructure;
public class PaymentPlanConfiguration : IEntityTypeConfiguration<PaymentPlan>
{
    public void Configure(EntityTypeBuilder<PaymentPlan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Installments)
            .WithOne(y => y.PaymentPlan)
            .HasForeignKey(z => z.PaymentPlanId);
    }
}