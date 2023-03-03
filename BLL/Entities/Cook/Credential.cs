namespace BLL.Entities.Cook;

public class Credential
{
    private string _email;
    private string _hashedPassword;
    private DateTime _updatedAt;
    
    public Credential(string email, string password, DateTime updatedAt)
    {
        _email = email;
        _hashedPassword = password;
        _updatedAt = updatedAt;
    }
    
    public string Email => _email;
    public string Password => _hashedPassword;
    public DateTime UpdatedAt => _updatedAt;
    
    public void UpdateEmail(string email)
    {
        _email = email;
    }
    
    public void UpdatePassword(string hashedPassword)
    {
        _hashedPassword = hashedPassword;
        _updatedAt = DateTime.Now;
    }
}