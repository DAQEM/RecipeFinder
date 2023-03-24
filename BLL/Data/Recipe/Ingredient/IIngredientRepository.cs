namespace BLL.Data.Recipe.Ingredient;

public interface IIngredientRepository
{
    List<Entities.Recipe.Ingredient.Ingredient> GetByRecipeId(Guid id);
    void DeleteByRecipeId(Guid recipeId);
    void Add(Guid recipeId, Entities.Recipe.Ingredient.Ingredient recipeIngredients);
}