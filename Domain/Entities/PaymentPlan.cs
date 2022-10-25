namespace Zip.InstallmentsService;

/// <summary>
/// Data structure which defines all the properties for a purchase installment plan.
/// </summary>
public class PaymentPlan
{
    public const int INSTALLMENT_INTERVAL_IN_DAYS = 14;

    public Guid Id { get; set; }

    public decimal PurchaseAmount { get; set; }

    public virtual ICollection<Installment>? Installments { get; set; }

    public PaymentPlan()
    {
        Id = Guid.NewGuid();
        Installments = Enumerable.Empty<Installment>().ToList();
    }

    public PaymentPlan CreateInstallments(
        DateTime purchaseDate,
        decimal purchaseAmount,
        int installmentCount)
    {

        if (installmentCount == 0 || purchaseAmount == 0)
            return this;

        decimal installmentAmount = purchaseAmount / installmentCount;

        Installments = Enumerable.Range(0, installmentCount).Select(x => new Installment()
        {
            Amount = installmentAmount,
            DueDate = purchaseDate.AddDays(x * INSTALLMENT_INTERVAL_IN_DAYS),
            PaymentPlanId = Id,
        }).ToList();

        return this;
    }
}
