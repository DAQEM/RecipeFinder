namespace BLL.Data.Recipe;

public interface IRecipeService
{
    Entities.Recipe.Recipe? GetById(Guid id);
    List<Entities.Recipe.Recipe> GetByCookId(Guid cookId);
}