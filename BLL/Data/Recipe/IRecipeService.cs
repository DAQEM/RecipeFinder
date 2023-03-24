using BLL.Exceptions;

namespace BLL.Data.Recipe;

public interface IRecipeService
{
    
    /// <exception cref="NotFoundException">When the recipe was not found</exception>
    Entities.Recipe.Recipe GetById(Guid id);
    Entities.Recipe.Recipe GetByIdWithReviews(Guid id);
    Entities.Recipe.Recipe GetByIdDetailed(Guid id);
    List<Entities.Recipe.Recipe> GetByCookId(Guid cookId);
    List<Entities.Recipe.Recipe> GetByCookIdWithReviews(Guid cookId);
    List<Entities.Recipe.Recipe> GetBySearch(string searchString);
    List<Entities.Recipe.Recipe> GetLikedByCookId(Guid cookId);
    List<Entities.Recipe.Recipe> GetSavedByCookId(Guid cookId);
    void UpdateWithIngredientsAndPreparationSteps(Guid recipeId, Entities.Recipe.Recipe recipe);
    void CreateWithIngredientsAndPreparationSteps(Entities.Recipe.Recipe recipe, Guid viewerId);
}