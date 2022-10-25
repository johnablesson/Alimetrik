namespace Zip.InstallmentsService.Commands;

public sealed class CreatePaymentPlanCommand : IRequest<PaymentPlanResponse>
{
    public CreatePaymentPlanRequest PaymentPlanRequest;

    public CreatePaymentPlanCommand(CreatePaymentPlanRequest paymentPlanRequest)
    {
        PaymentPlanRequest = paymentPlanRequest;
    }
}
