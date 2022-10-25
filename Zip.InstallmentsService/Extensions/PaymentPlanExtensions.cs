namespace Zip.InstallmentsService.Extensions;

public static class PaymentPlanExtensions
{
    public static InstallmentResponse AsInstallmentResponse(this Installment installment)
    {
        if (installment is null)
            return default;

        return new InstallmentResponse(installment.Id, installment.DueDate, installment.Amount);
    }

    public static PaymentPlanResponse AsPaymentPlanResponse(this PaymentPlan paymentPlan)
    {
        if (paymentPlan == null)
            return default;

        if (paymentPlan.Installments?.ToList().Any() is true)
        {
            return new PaymentPlanResponse(paymentPlan.Id, paymentPlan.PurchaseAmount, paymentPlan.Installments.Select(x => x.AsInstallmentResponse()));
        }

        return new PaymentPlanResponse(paymentPlan.Id, paymentPlan.PurchaseAmount, Enumerable.Empty<InstallmentResponse>());
    }
}
