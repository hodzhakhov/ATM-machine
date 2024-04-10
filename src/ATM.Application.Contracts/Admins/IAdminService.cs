namespace ATM.Application.Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string password);
    void Logout();

    void CreateAccount(int number, int pin);
}