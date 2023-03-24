namespace BLL.Data.Recipe.Ingredient;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;
    
    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public List<Entities.Recipe.Ingredient.Ingredient> GetByRecipeId(Guid id)
    {
        return _ingredientRepository.GetByRecipeId(id);
    }

    public void UpdateForRecipeId(Guid recipeId, Entities.Recipe.Ingredient.Ingredient[] recipeIngredients)
    {
        _ingredientRepository.DeleteByRecipeId(recipeId);
        foreach (Entities.Recipe.Ingredient.Ingredient ingredient in recipeIngredients)
        {
            _ingredientRepository.Add(recipeId, ingredient);
        }
    }

    public void CreateForRecipeId(Guid recipeId, Entities.Recipe.Ingredient.Ingredient[] recipeIngredients)
    {
        foreach (Entities.Recipe.Ingredient.Ingredient ingredient in recipeIngredients)
        {
            _ingredientRepository.Add(recipeId, ingredient);
        }
    }
}