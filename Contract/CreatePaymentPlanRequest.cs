namespace ApiContract;

public record CreatePaymentPlanRequest(DateTime PurhcaseDate, decimal PurchaseAmount, int Installments);
