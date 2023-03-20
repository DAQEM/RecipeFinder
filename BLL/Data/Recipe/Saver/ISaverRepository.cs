namespace BLL.Data.Recipe.Saver;

public interface ISaverRepository
{
    List<Entities.Cook.Cook> GetForRecipeId(Guid recipeId);
    void Add(Guid recipeId, Guid cookId);
    void Remove(Guid recipeId, Guid cookId);
}