using ATM.Application.Contracts.Accounts;
using ATM.Application.Models.Accounts;

namespace ATM.Application.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}