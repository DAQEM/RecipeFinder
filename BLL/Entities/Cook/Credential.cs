namespace BLL.Entities.Cook;

public class Credential
{
    private readonly string _email;
    private readonly string _hashedPassword;
    private readonly DateTime _updatedAt;
    
    public Credential(string email, string password, DateTime updatedAt)
    {
        _email = email;
        _hashedPassword = password;
        _updatedAt = updatedAt;
    }
    
    public static Credential Empty => new(string.Empty, string.Empty, DateTime.Now);
    public string Email => _email;
    public string Password => _hashedPassword;
    public DateTime UpdatedAt => _updatedAt;
}