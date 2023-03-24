namespace BLL.Data.Recipe;

public interface IRecipeRepository
{
    Entities.Recipe.Recipe? GetById(Guid id);
    List<Entities.Recipe.Recipe> GetByCookId(Guid cookId);
    List<Entities.Recipe.Recipe> GetBySearch(string searchString);
    List<Entities.Recipe.Recipe> GetLikedByCookId(Guid cookId);
    List<Entities.Recipe.Recipe> GetSavedByCookId(Guid cookId);
    void Update(Entities.Recipe.Recipe recipe);
    void Create(Entities.Recipe.Recipe recipe);
}