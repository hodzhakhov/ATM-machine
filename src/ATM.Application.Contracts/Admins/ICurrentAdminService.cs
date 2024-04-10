using ATM.Application.Models.Admins;

namespace ATM.Application.Contracts.Admins;

public interface ICurrentAdminService
{
    Admin? Admin { get; }
}