using BLL.Entities.Recipe;
using BLL.Entities.Review;

namespace BLL.Data.Cook;

public class CookService : ICookService
{
    private readonly ICookRepository _cookRepository;

    public CookService(ICookRepository cookRepository)
    {
        _cookRepository = cookRepository;
    }
    
    public List<Entities.Cook.Cook> GetAll()
    {
        return _cookRepository.GetAll();
    }
    
    public Entities.Cook.Cook? GetById(Guid id)
    {
        return _cookRepository.GetById(id);
    }
    
    public Entities.Cook.Cook? GetByUsername(string username)
    {
        return _cookRepository.GetByUserName(username);
    }
    
    public void Add(Entities.Cook.Cook cook)
    {
        _cookRepository.Add(cook);
    }
    
    public void Update(Entities.Cook.Cook cook)
    {
        _cookRepository.Update(cook);
    }
    
    public void Delete(string username)
    {
        _cookRepository.Delete(username);
    }

    public Entities.Cook.Cook? GetByUsernameWithRecipes(string username)
    {
        return _cookRepository.GetByUsernameWithRecipes(username);
    }

    public Entities.Cook.Cook? GetByUsernameWithCookReviews(string username)
    {
        return _cookRepository.GetByUsernameWithCookReviews(username);
    }

    public Entities.Cook.Cook? GetByRecipeIdWithRecipe(Guid recipeId)
    {
        return _cookRepository.GetByRecipeIdWithRecipe(recipeId);
    }
}