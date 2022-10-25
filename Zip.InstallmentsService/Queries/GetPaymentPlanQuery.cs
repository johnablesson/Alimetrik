namespace Zip.InstallmentsService.Queries;

public class GetPaymentPlanQuery : IRequest<PaymentPlanResponse>
{
    public Guid PaymentPlanId;
    public GetPaymentPlanQuery(Guid paymentPlanId)
    {
        PaymentPlanId = paymentPlanId;
    }
}
