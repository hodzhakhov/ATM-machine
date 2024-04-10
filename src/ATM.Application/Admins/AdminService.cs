using ATM.Application.Abstractions.Repositories;
using ATM.Application.Contracts;
using ATM.Application.Contracts.Admins;
using ATM.Application.Models.Admins;

namespace ATM.Application.Admins;

internal class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly CurrentAdminManager _currentAdminManager;

    public AdminService(IAdminRepository repository, CurrentAdminManager currentAdminManager)
    {
        _repository = repository;
        _currentAdminManager = currentAdminManager;
    }

    public LoginResult Login(string password)
    {
        Task<Admin?> admin = _repository.FindAdmin(password);

        if (admin.Result is null)
        {
            return new LoginResult.NotFound();
        }

        _currentAdminManager.Admin = admin.Result;
        return new LoginResult.Success();
    }

    public void Logout()
    {
        _currentAdminManager.Admin = null;
    }

    public void CreateAccount(int number, int pin)
    {
        if (_currentAdminManager.Admin is not null)
            _repository.CreateAccount(number, pin);
    }
}