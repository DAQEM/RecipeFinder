namespace BLL.Data.Auth;

public interface IAuthService
{
    string? Login(string username, string password);
    void Register(string username, string fullName, string email, string password);
    void ChangePassword(string username, string oldPassword, string newPassword);
}