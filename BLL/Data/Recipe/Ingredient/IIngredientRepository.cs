namespace BLL.Data.Recipe.Ingredient;

public interface IIngredientRepository
{
    List<Entities.Recipe.Ingredient.Ingredient> GetByRecipeId(Guid id);
}