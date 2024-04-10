using ATM.Application.Abstractions.Repositories;
using ATM.Application.Contracts;
using ATM.Application.Models.Accounts;
using ATM.Application.Models.Transactions;

namespace ATM.Infrastructure.DataAccess.Repositories;

public class MockAccountRepository : IAccountRepository
{
    public long Mock { get; private set; }

    public Task<Account?> FindAccountByNumber(int number)
    {
        throw new NotImplementedException();
    }

    public Task AddMoney(long amount, Account account)
    {
        account = account with { Balance = account.Balance + amount };
        Mock = account.Balance;
        return Task.FromResult(true);
    }

    public Task WithdrawalMoney(long amount, Account account)
    {
        if (account.Balance - amount >= 0)
        {
            Mock = account.Balance - amount;
            return Task.FromResult<WithdrawalResult>(new WithdrawalResult.Success());
        }

        return Task.FromResult<WithdrawalResult>(new WithdrawalResult.Failed());
    }

    public Task<long> GetBalance(Account account)
    {
        Mock = 0;
        return Task.FromResult(account.Balance);
    }

    public Task<IEnumerable<Transaction>> GetAllTransactions(Account account)
    {
        throw new NotImplementedException();
    }
}