using BLL.Exceptions;

namespace BLL.Entities.Cook;

public class Credential
{
    private Guid _id;
    private string _email;
    private string _hashedPassword;
    private DateTime _updatedAt;
    private Guid _cookId;
    
    private Credential(Guid id, string email, string password, DateTime updatedAt, Guid cookId)
    {
        _id = id;
        _email = email;
        _hashedPassword = password;
        _updatedAt = updatedAt;
        _cookId = cookId;
    }

    public Guid Id { get => _id; set => _id = value; }
    public string Email { get => _email; set => _email = value; }
    public string HashedPassword { get => _hashedPassword; set => _hashedPassword = value; }
    public DateTime UpdatedAt { get => _updatedAt; set => _updatedAt = value; }
    public Guid CookId { get => _cookId; set => _cookId = value; }
    
    public static Credential Empty => new(Guid.Empty, string.Empty, string.Empty, DateTime.Now, Guid.Empty);

    public class Builder
    {
        private Credential _credential = Empty;
        
        public Builder FromCredential(Credential credential)
        {
            _credential = credential;
            return this;
        }
        
        public Builder WithId(Guid id)
        {
            _credential.Id = id;
            return this;
        }
        
        public Builder WithEmail(string email)
        {
            _credential.Email = email;
            return this;
        }
        
        public Builder WithPassword(string password)
        {
            _credential.HashedPassword = password;
            return this;
        }

        public Builder WithUpdatedAt(DateTime updatedAt)
        {
            _credential.UpdatedAt = updatedAt;
            return this;
        }
        
        public Builder WithCookId(Guid cookId)
        {
            _credential.CookId = cookId;
            return this;
        }
        
        public Credential Build()
        {
            if (_credential.Email == null || _credential.HashedPassword == null || _credential.CookId == Guid.Empty)
            {
                throw new IncompleteBuilderException(typeof(Credential));
            }
            return _credential;
        }
    }
}