namespace BLL.Data.Recipe;

public interface IRecipeRepository
{
    Entities.Recipe.Recipe? GetById(Guid id);
    List<Entities.Recipe.Recipe> GetByCookId(Guid cookId);
    List<Entities.Recipe.Recipe> GetBySearch(string searchString);
}