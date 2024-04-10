using System.Globalization;
using ATM.Application.Contracts.Accounts;
using ATM.Application.Models.Transactions;
using Spectre.Console;

namespace ATM.Presentation.Console.Scenarios.GetTransactions;

public class GetTransactionsScenario : IScenario
{
    private readonly IAccountService _accountService;

    public GetTransactionsScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Get transactions";

    public void Run()
    {
        var transactions = _accountService.GetAllTransactions().ToList();
        foreach (Transaction transaction in transactions)
        {
            AnsiConsole.Write(CultureInfo.CurrentCulture, $"Account number: {transaction.AccountNumber}, Transaction type: {transaction.Type}, Amount: {transaction.Amount}");
            AnsiConsole.WriteLine();
        }

        AnsiConsole.Ask<string>("Ok");
    }
}