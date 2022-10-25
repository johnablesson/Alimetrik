namespace Zip.InstallmentsService.Commands;

public sealed class CreatePaymentPlanCommandHandler : IRequestHandler<CreatePaymentPlanCommand, PaymentPlanResponse>
{
    private readonly IInstallmentServiceDbContext _context;

    public CreatePaymentPlanCommandHandler(IInstallmentServiceDbContext context)
    {
        _context = context;
    }

    public async Task<PaymentPlanResponse> Handle(CreatePaymentPlanCommand request, CancellationToken cancellationToken)
    {
        var planRequest = request.PaymentPlanRequest;

        PaymentPlan plan = new()
        {
            PurchaseAmount = planRequest.PurchaseAmount
        };

        plan.CreateInstallments(planRequest.PurhcaseDate, planRequest.PurchaseAmount, planRequest.Installments);

        await _context.PaymentPlans.AddAsync(plan);

        await _context.Save(cancellationToken);

        return plan.AsPaymentPlanResponse();

    }
}
