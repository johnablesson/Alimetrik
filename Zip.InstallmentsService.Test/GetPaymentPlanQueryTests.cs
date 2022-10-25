namespace Zip.InstallmentsService.Testl;

public class GetPaymentPlanQueryTests : BaseTest
{
    /// <summary>
    /// Test the GetPaymentPlanQuery query gets the Payment Plan Successfully for a valid Payment Id
    /// </summary>
    /// <param name="purchaseAmount"></param>
    /// <param name="installmentCount"></param>
    /// <param name="installmentAmount"></param>
    /// <returns></returns>
    [Theory]
    [InlineData(1000, 4, 250)]
    [InlineData(1250, 4, 312.5)]
    [InlineData(1999, 4, 499.75)]
    public async Task ShouldGetPaymentPlanSuccessfully(decimal purchaseAmount, int installmentCount, decimal installmentAmount)
    {
        DateTime purchaseDate = new(2023, 01, 01);
        CreatePaymentPlanRequest request = new(purchaseDate, purchaseAmount, installmentCount);
        CreatePaymentPlanCommand command = new(request);
        CreatePaymentPlanCommandHandler handler = new(_context);
        PaymentPlanResponse result = await handler.Handle(command, CancellationToken.None);

        GetPaymentPlanQuery query = new(result.PaymentPlanId);
        GetPaymentPlanQueryHandler queryHandler = new(_context);
        PaymentPlanResponse queryResult = await queryHandler.Handle(query, CancellationToken.None);

        using AssertionScope scope = new();

        queryResult.Should().NotBeNull();
        queryResult.PurchaseAmount.Should().Be(purchaseAmount);
        queryResult.Installments.Should().HaveCount(installmentCount);

        foreach (InstallmentResponse installment in queryResult.Installments)
        {
            installment.Amount.Should().Be(installmentAmount);
        }

    }



    /// <summary>
    /// Test the GetPaymentPlanQuery query returns null for an invalid Payment Plan Id
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task GetPaymentPlanShouldReturnNullForInvalidPlanId()
    {
        GetPaymentPlanQuery query = new(Guid.NewGuid());
        GetPaymentPlanQueryHandler queryHandler = new(_context);
        PaymentPlanResponse queryResult = await queryHandler.Handle(query, CancellationToken.None);
        queryResult.Should().BeNull();
    }
}
