using BLL.Exceptions;

namespace BLL.Data.Cook.Credential;

public interface ICredentialService
{
    void Add(Entities.Cook.Credential credential);
    void Update(Entities.Cook.Credential credential);
    
    /// <exception cref="NotFoundException">When the credentials were not found</exception>
    Entities.Cook.Credential GetByCookId(Guid cookId);
}