using BLL.Entities.Review;

namespace BLL.Data.Cook;

public interface ICookService
{
    List<Entities.Cook.Cook> GetAll();
    Entities.Cook.Cook? GetById(Guid id);
    Entities.Cook.Cook? GetByUsername(string username);
    void Add(Entities.Cook.Cook cook);
    void Update(Entities.Cook.Cook cook);
    void Delete(string username);
    Entities.Cook.Cook? GetByUsernameWithRecipes(string username);
    Entities.Cook.Cook? GetByUsernameWithCookReviews(string username);
    Entities.Cook.Cook? GetByRecipeIdWithRecipe(Guid recipeId);
}