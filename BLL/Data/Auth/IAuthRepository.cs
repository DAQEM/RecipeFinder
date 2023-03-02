namespace BLL.Data.Auth;

public interface IAuthRepository
{
    string? Login(string username, string password);
    void Register(Guid cookId, Guid credentialId, string username, string fullName, string email, string password);
}