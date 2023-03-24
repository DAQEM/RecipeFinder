using BLL.Data.Cook;
using BLL.Data.Cook.Credential;
using BLL.Entities.Cook;
using BLL.Exceptions;
using BLL.Security;

namespace BLL.Data.Auth;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ICookService _cookService;
    private readonly ICredentialService _credentialService;

    public AuthService(IAuthRepository authRepository, ICookService cookService, ICredentialService credentialService)
    {
        _authRepository = authRepository;
        _cookService = cookService;
        _credentialService = credentialService;
    }

    public string? Login(string username, string password)
    {
        string hashedPassword = PasswordSecurity.HashPassword(password);
        return _authRepository.Login(username, hashedPassword);
    }
    
    public void Register(string username, string fullName, string email, string password)
    {
        if (IsUsernameTaken(username)) throw new UsernameTakenException();
        if (IsEmailTaken(email)) throw new EmailTakenException();
        
        Guid cookId = Guid.NewGuid();
        string hashedPassword = PasswordSecurity.HashPassword(password);
        
        _cookService.Add(new Entities.Cook.Cook(
            id: cookId,
            username: username,
            fullname: fullName,
            imageUrl: "https://i.imgur.com/ShL15rC.png"
        ));
        _credentialService.Add(new Credential(
            cookId: cookId,
            email: email,
            hashedPassword: hashedPassword
        ));
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        string hashedOldPassword = PasswordSecurity.HashPassword(oldPassword);
        string hashedNewPassword = PasswordSecurity.HashPassword(newPassword);
        
        if (!PasswordCorrect(username, hashedOldPassword)) throw new WrongPasswordException();
        
        Entities.Cook.Cook? cook = _cookService.GetByUsername(username);

        if (cook == null) throw new UsernameNotFoundException();
        {
            _credentialService.Update(new Credential(
                cookId: cook.Id,
                email: cook.Credential.Email,
                hashedPassword: hashedNewPassword
            ));
        }
    }

    public bool IsUsernameTaken(string username)
    {
        return _authRepository.IsUsernameTaken(username);
    }

    public bool IsEmailTaken(string email)
    {
        return _authRepository.IsEmailTaken(email);
    }

    public bool PasswordCorrect(string username, string hashedPassword)
    {
        return _authRepository.PasswordCorrect(username, hashedPassword);
    }
}