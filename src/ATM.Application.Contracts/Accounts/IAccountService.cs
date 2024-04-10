using ATM.Application.Models.Transactions;

namespace ATM.Application.Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(int number, int pin);
    void Logout();

    void AddMoney(long amount);
    Task<WithdrawalResult> WithdrawalMoney(long amount);
    long GetBalance();
    IEnumerable<Transaction> GetAllTransactions();
}