namespace Zip.InstallmentsService.Queries;

public class GetPaymentPlanQueryHandler : IRequestHandler<GetPaymentPlanQuery, PaymentPlanResponse>
{
    private readonly IInstallmentServiceDbContext _context;
    public GetPaymentPlanQueryHandler(IInstallmentServiceDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentPlanResponse> Handle(GetPaymentPlanQuery request, CancellationToken cancellationToken)
    {
        PaymentPlan paymentPlan = await _context.PaymentPlans
            .AsNoTracking()
            .Include(y => y.Installments)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.PaymentPlanId, cancellationToken);

        return paymentPlan.AsPaymentPlanResponse();
    }
}