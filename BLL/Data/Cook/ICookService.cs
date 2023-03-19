using BLL.Exceptions;

namespace BLL.Data.Cook;

public interface ICookService
{
    List<Entities.Cook.Cook> GetAll();
    
    /// <exception cref="NotFoundException">When the cook was not found</exception>
    Entities.Cook.Cook GetById(Guid id);
    
    /// <exception cref="NotFoundException">When the cook was not found</exception>
    Entities.Cook.Cook GetByUsername(string username);
    void Add(Entities.Cook.Cook cook);
    void Update(Entities.Cook.Cook cook);
    void UpdateWithCredentials(Entities.Cook.Cook build);
    void Delete(string username);
    
    /// <exception cref="NotFoundException">When the cook was not found</exception>
    Entities.Cook.Cook GetByUsernameWithRecipes(string username);
    
    /// <exception cref="NotFoundException">When the cook was not found</exception>
    Entities.Cook.Cook GetByUsernameWithCookReviews(string username);
    
    /// <exception cref="NotFoundException">When the cook or the credential was not found</exception>
    Entities.Cook.Cook GetByUsernameWithCredentials(string username);
    
    /// <exception cref="NotFoundException">When the cook was not found</exception>
    Entities.Cook.Cook GetByUsernameWithFollowers(string username);
    
    /// <exception cref="NotFoundException">When the cook or the recipe was not found</exception>
    Entities.Cook.Cook GetWithRecipe(Guid recipeId);

    List<Entities.Cook.Cook> GetBySearch(string searchString);
}