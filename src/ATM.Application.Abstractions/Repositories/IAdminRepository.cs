using ATM.Application.Models.Admins;

namespace ATM.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Admin?> FindAdmin(string password);

    void CreateAccount(int number, int pin);
}