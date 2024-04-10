using ATM.Application.Abstractions.Repositories;
using ATM.Application.Contracts;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Models.Accounts;
using ATM.Application.Models.Transactions;

namespace ATM.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly CurrentAccountManager _currentAccountManager;

    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository, CurrentAccountManager currentAccountManager)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _currentAccountManager = currentAccountManager;
    }

    public LoginResult Login(int number, int pin)
    {
        Task<Account?> account = _accountRepository.FindAccountByNumber(number);

        if (account.Result != null && account.Result.Pin != pin)
        {
            return new LoginResult.NotFound();
        }

        _currentAccountManager.Account = account.Result;
        return new LoginResult.Success();
    }

    public void Logout()
    {
        _currentAccountManager.Account = null;
    }

    public async void AddMoney(long amount)
    {
        if (_currentAccountManager.Account != null)
        {
            await _accountRepository.AddMoney(amount, _currentAccountManager.Account).ConfigureAwait(false);
            _transactionRepository.AddTransaction(new Transaction(_currentAccountManager.Account.Number, TransactionType.Replenishment, amount));
        }
    }

    public async Task<WithdrawalResult> WithdrawalMoney(long amount)
    {
        if (_currentAccountManager.Account != null)
        {
            long balance = GetBalance();
            if (balance - amount >= 0)
            {
                await _accountRepository.WithdrawalMoney(amount, _currentAccountManager.Account).ConfigureAwait(false);
                _transactionRepository.AddTransaction(new Transaction(_currentAccountManager.Account.Number, TransactionType.Withdrawal, amount));
                return new WithdrawalResult.Success();
            }
        }

        return new WithdrawalResult.Failed();
    }

    public long GetBalance()
    {
        if (_currentAccountManager.Account != null)
            return _accountRepository.GetBalance(_currentAccountManager.Account).Result;
        return 0;
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        if (_currentAccountManager.Account != null)
            return _accountRepository.GetAllTransactions(_currentAccountManager.Account).Result;
        return new List<Transaction>();
    }
}