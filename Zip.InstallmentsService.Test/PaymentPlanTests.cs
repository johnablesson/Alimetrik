namespace Zip.InstallmentsService.Test;
public class PaymentPlanTests
{
    [Theory]
    [InlineData(1000, 4, 250)]
    [InlineData(1250, 4, 312.5)]
    [InlineData(1999, 4, 499.75)]
    public void PaymentPlanShouldCreateSuccessfully(decimal purchaseAmount, int installmentCount, decimal installmentAmount)
    {
        DateTime purchaseDate = new(2023, 01, 01);

        PaymentPlan plan = new()
        {
            Id = Guid.NewGuid(),
            PurchaseAmount = purchaseAmount,
        };

        plan.CreateInstallments(purchaseDate, purchaseAmount, installmentCount);

        using var scope = new AssertionScope();

        plan.Should().NotBeNull();
        plan.PurchaseAmount.Should().Be(purchaseAmount);
        plan.Installments.Should().HaveCount(installmentCount);
        plan.Installments.ToList()[0].Amount.Should().Be(installmentAmount);
    }


    [Theory]
    [InlineData(0, 0)]
    [InlineData(1000, 0)]
    [InlineData(0, 4)]
    public void PaymentPlanShouldNotHaveAnyInstallments(decimal purchaseAmount, int installmentCount)
    {
        DateTime purchaseDate = new(2023, 01, 01);

        PaymentPlan plan = new()
        {
            Id = Guid.NewGuid(),
            PurchaseAmount = purchaseAmount,
        };

        plan.CreateInstallments(purchaseDate, purchaseAmount, installmentCount);

        using var scope = new AssertionScope();

        plan.Should().NotBeNull();
        plan.PurchaseAmount.Should().Be(purchaseAmount);
        plan.Installments.Should().HaveCount(0);
    }
}
