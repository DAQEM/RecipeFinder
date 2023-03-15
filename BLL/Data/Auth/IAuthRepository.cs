namespace BLL.Data.Auth;

public interface IAuthRepository
{
    string? Login(string username, string hashedPassword); 
    bool IsUsernameTaken(string username);
    bool IsEmailTaken(string email);
    bool PasswordCorrect(string username, string hashedPassword);
}