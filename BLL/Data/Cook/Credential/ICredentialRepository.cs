namespace BLL.Data.Cook.Credential;

public interface ICredentialRepository
{
    void Add(Guid id, string email, string hashedPassword, Guid cookId);
    void Update(string email, string hashedPassword, Guid cookId);
}