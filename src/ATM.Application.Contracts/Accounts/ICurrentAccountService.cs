using ATM.Application.Models.Accounts;

namespace ATM.Application.Contracts.Accounts;

public interface ICurrentAccountService
{
    Account? Account { get; }
}