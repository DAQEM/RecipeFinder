namespace BLL.Data.Recipe.Liker;

public class LikerService : ILikerService
{
    private readonly ILikerRepository _likerRepository;
    
    public LikerService(ILikerRepository likerRepository)
    {
        _likerRepository = likerRepository;
    }
    
    public List<Entities.Cook.Cook> GetForRecipeId(Guid recipeId)
    {
        return _likerRepository.GetForRecipeId(recipeId);
    }

    public void Add(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook)
    {
        _likerRepository.Add(recipe.Id, cook.Id);
    }

    public void Remove(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook)
    {
        _likerRepository.Remove(recipe.Id, cook.Id);
    }
}