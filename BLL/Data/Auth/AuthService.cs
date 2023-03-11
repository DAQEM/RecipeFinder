using BLL.Security;

namespace BLL.Data.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public string? Login(string username, string password)
    {
        string hashedPassword = PasswordSecurity.HashPassword(password);
        return _authRepository.Login(username, hashedPassword);
    }
    
    public void Register(string username, string fullName, string email, string password)
    {
        Guid cookId = Guid.NewGuid();
        Guid credentialId = Guid.NewGuid();
        string hashedPassword = PasswordSecurity.HashPassword(password);
        _authRepository.Register(cookId, credentialId, username, fullName, email, hashedPassword);
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        string hashedOldPassword = PasswordSecurity.HashPassword(oldPassword);
        string hashedNewPassword = PasswordSecurity.HashPassword(newPassword);
        _authRepository.ChangePassword(username, hashedOldPassword, hashedNewPassword);
    }
}