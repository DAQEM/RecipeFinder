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
}