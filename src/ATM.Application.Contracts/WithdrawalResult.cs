namespace ATM.Application.Contracts;

public record WithdrawalResult
{
    private WithdrawalResult() { }

    public sealed record Success : WithdrawalResult;

    public sealed record Failed : WithdrawalResult;
}