namespace BLL.Data.Recipe.Saver;

public class SaverService : ISaverService
{
    private readonly ISaverRepository _saverRepository;
    
    public SaverService(ISaverRepository saverRepository)
    {
        _saverRepository = saverRepository;
    }
    
    public List<Entities.Cook.Cook> GetForRecipeId(Guid recipeId)
    {
        return _saverRepository.GetForRecipeId(recipeId);
    }

    public void Add(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook)
    {
        _saverRepository.Add(recipe.Id, cook.Id);
    }

    public void Remove(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook)
    {
        _saverRepository.Remove(recipe.Id, cook.Id);
    }
}