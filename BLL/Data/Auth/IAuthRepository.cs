namespace BLL.Data.Auth;

public interface IAuthRepository
{
    string? Login(string username, string hashedPassword);
    void Register(Guid cookId, Guid credentialId, string username, string fullName, string email, string hashedPassword);
}