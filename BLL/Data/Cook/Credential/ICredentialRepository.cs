namespace BLL.Data.Cook.Credential;

public interface ICredentialRepository
{
    void Add(string email, string hashedPassword, Guid cookId);
    void Update(string email, string hashedPassword, Guid cookId);
    Entities.Cook.Credential? GetByCookId(Guid cookId);
}