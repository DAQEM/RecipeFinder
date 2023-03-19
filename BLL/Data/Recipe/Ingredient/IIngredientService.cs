namespace BLL.Data.Recipe.Ingredient;

public interface IIngredientService
{
    List<Entities.Recipe.Ingredient.Ingredient> GetByRecipeId(Guid id);
}