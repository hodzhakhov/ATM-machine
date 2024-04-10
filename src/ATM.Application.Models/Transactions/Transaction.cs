namespace ATM.Application.Models.Transactions;

public record Transaction(long AccountNumber, TransactionType Type, long Amount);