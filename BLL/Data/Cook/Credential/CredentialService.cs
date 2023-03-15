﻿namespace BLL.Data.Cook.Credential;

public class CredentialService : ICredentialService
{
    private readonly ICredentialRepository _credentialRepository;
    
    public CredentialService(ICredentialRepository credentialRepository)
    {
        _credentialRepository = credentialRepository;
    }
    
    public void Add(Entities.Cook.Credential credential)
    {
        _credentialRepository.Add(credential.Id, credential.Email, credential.HashedPassword, credential.CookId);
    }

    public void Update(Entities.Cook.Credential credential)
    {
        _credentialRepository.Update(credential.Email, credential.HashedPassword, credential.CookId);
    }
}