namespace ApiContract;

public record InstallmentResponse(Guid Id, DateTime DueDate, decimal Amount);