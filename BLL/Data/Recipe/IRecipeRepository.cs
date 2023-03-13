namespace BLL.Data.Recipe;

public interface IRecipeRepository
{
    List<Entities.Recipe.Recipe> GetRecipesByUsername(string username);
}