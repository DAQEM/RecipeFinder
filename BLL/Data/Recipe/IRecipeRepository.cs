namespace BLL.Data.Recipe;

public interface IRecipeRepository
{
    Entities.Recipe.Recipe? GetById(Guid id);
    List<Entities.Recipe.Recipe> GetByCookId(Guid cookId);
}