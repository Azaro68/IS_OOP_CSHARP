namespace Lab5.Application.Models.Operations;

public record Operation(
    long OperationId,
    long UserId,
    OperationType OperationType,
    decimal Amount,
    string Result);
