using ATM.Application.Contracts.Admins;
using ATM.Application.Models.Admins;

namespace ATM.Application.Admins;

internal class CurrentAdminManager : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}