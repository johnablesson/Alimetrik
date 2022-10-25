namespace Zip.InstallmentsService.Validators;

public sealed class CreatePaymentPlanRequestValidator: AbstractValidator<CreatePaymentPlanRequest>
{
	public CreatePaymentPlanRequestValidator()
	{
		RuleFor(x => x.PurchaseAmount).GreaterThan(0);
		RuleFor(x => x.Installments).GreaterThan(0);
	}
}
