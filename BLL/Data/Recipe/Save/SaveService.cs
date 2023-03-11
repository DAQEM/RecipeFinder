namespace BLL.Data.Recipe.Save;

public class SaveService : ISaveService
{
    private readonly ISaveRepository _saveRepository;
    
    public SaveService(ISaveRepository saveRepository)
    {
        _saveRepository = saveRepository;
    }
}