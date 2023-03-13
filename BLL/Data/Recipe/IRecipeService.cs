namespace BLL.Data.Recipe;

public interface IRecipeService
{
    List<Entities.Recipe.Recipe> GetRecipesByUsername(string username);
}