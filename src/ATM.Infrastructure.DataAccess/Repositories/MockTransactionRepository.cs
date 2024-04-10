using ATM.Application.Abstractions.Repositories;
using ATM.Application.Models.Transactions;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class MockTransactionRepository : ITransactionRepository
{
    public void AddTransaction(Transaction transaction)
    {
    }
}