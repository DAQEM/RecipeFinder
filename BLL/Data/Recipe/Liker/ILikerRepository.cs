namespace BLL.Data.Recipe.Liker;

public interface ILikerRepository
{
    List<Entities.Cook.Cook> GetForRecipeId(Guid recipeId);
    void Add(Guid recipeId, Guid cookId);
    void Remove(Guid recipeId, Guid cookId);
}