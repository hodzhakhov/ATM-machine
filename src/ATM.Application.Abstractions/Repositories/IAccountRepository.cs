using ATM.Application.Models.Accounts;
using ATM.Application.Models.Transactions;

namespace ATM.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Task<Account?> FindAccountByNumber(int number);

    Task AddMoney(long amount, Account account);
    Task WithdrawalMoney(long amount, Account account);
    Task<long> GetBalance(Account account);
    Task<IEnumerable<Transaction>> GetAllTransactions(Account account);
}