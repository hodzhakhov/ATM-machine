using ATM.Application.Models.Transactions;

namespace ATM.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    void AddTransaction(Transaction transaction);
}