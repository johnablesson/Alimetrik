namespace ApiContract;

public record PaymentPlanResponse(Guid PaymentPlanId, decimal PurchaseAmount, IEnumerable<InstallmentResponse>? Installments);
