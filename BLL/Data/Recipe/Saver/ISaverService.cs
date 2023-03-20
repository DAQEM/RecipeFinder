namespace BLL.Data.Recipe.Saver;

public interface ISaverService
{
    List<Entities.Cook.Cook> GetForRecipeId(Guid recipeId); 
    
    void Add(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook);
    
    void Remove(Entities.Recipe.Recipe recipe, Entities.Cook.Cook cook);
}