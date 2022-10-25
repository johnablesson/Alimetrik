namespace Zip.InstallmentsService.Test;


public class CreatePaymentPlanCommandTests : BaseTest
{
    public CreatePaymentPlanCommandTests()
    {
    }


    /// <summary>
    /// Test that the Mediator command CreatePaymentPlanCommand creates the Payment Plan successfully
    /// </summary>
    /// <param name="purchaseAmount"></param>
    /// <param name="installmentCount"></param>
    /// <param name="installmentAmount"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(1000, 4, 250)]
    [InlineData(1250, 4, 312.5)]
    [InlineData(1999, 4, 499.75)]
    public async Task ShouldCreatePaymentPlanSuccessfully(decimal purchaseAmount, int installmentCount, decimal installmentAmount)
    {
        DateTime purchaseDate = new(2023, 01, 01);

        var request = new CreatePaymentPlanRequest(purchaseDate, purchaseAmount, installmentCount);

        CreatePaymentPlanCommand command = new(request);
        CreatePaymentPlanCommandHandler handler = new(_context);
        var result = await handler.Handle(command, CancellationToken.None);

        using var scope = new AssertionScope();

        result.Should().NotBeNull();
        result.PurchaseAmount.Should().Be(purchaseAmount);
        result.Installments.Should().HaveCount(installmentCount);

        foreach (var installment in result.Installments)
        {
            installment.Amount.Should().Be(installmentAmount);
        }
    }

}
