namespace BLL.Data.Recipe;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    
    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public Entities.Recipe.Recipe? GetById(Guid id)
    {
        return _recipeRepository.GetById(id);
    }

    public List<Entities.Recipe.Recipe> GetByCookId(Guid cookId)
    {
        return _recipeRepository.GetByCookId(cookId);
    }
}