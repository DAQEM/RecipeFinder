namespace BLL.Data.Recipe;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    
    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public List<Entities.Recipe.Recipe> GetRecipesByUsername(string username)
    {
        return _recipeRepository.GetRecipesByUsername(username);
    }

    public Entities.Recipe.Recipe? GetById(Guid id)
    {
        return _recipeRepository.GetById(id);
    }
}