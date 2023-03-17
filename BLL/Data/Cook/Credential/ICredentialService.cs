namespace BLL.Data.Cook.Credential;

public interface ICredentialService
{
    void Add(Entities.Cook.Credential credential);
    void Update(Entities.Cook.Credential credential);
    Entities.Cook.Credential? GetByCookId(Guid cookId);
}