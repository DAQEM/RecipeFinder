namespace BLL.Data.Recipe.Ingredient;

public interface IIngredientService
{
    List<Entities.Recipe.Ingredient.Ingredient> GetByRecipeId(Guid id);
    void UpdateForRecipeId(Guid recipeId, Entities.Recipe.Ingredient.Ingredient[] recipeIngredients);
    void CreateForRecipeId(Guid recipeId, Entities.Recipe.Ingredient.Ingredient[] recipeIngredients);
}