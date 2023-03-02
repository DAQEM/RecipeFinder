namespace BLL.Data.Auth;

public class AuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    public string? Login(string username, string password)
    {
        return _authRepository.Login(username, password);
    }
    
    public void Register(string username, string fullName, string email, string password)
    {
        Guid cookId = Guid.NewGuid();
        Guid credentialId = Guid.NewGuid();
        _authRepository.Register(cookId, credentialId, username, fullName, email, password);
    }
}