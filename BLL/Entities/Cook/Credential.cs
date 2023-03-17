using BLL.Exceptions;

namespace BLL.Entities.Cook;

public class Credential
{
    private readonly string _email;
    private readonly string _hashedHashedPassword;
    private readonly DateTime _updatedAt;
    private readonly Guid _cookId;
    
    public Credential(string email = "", string hashedPassword = "", DateTime? updatedAt = null, Guid? cookId = null)
    {
        _email = email;
        _hashedHashedPassword = hashedPassword;
        _updatedAt = updatedAt ?? DateTime.MinValue;
        _cookId = cookId ?? Guid.Empty;
    }

    public string Email => _email;
    public string HashedPassword => _hashedHashedPassword;
    public DateTime UpdatedAt => _updatedAt;
    public Guid CookId => _cookId;
}