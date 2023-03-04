using BLL.Entities.Recipe;
using BLL.Entities.Review;

namespace BLL.Data.Cook;

public class CookService
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
    
    public Entities.Cook.Cook? GetByUserName(string username)
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
    
    public void Delete(Entities.Cook.Cook cook)
    {
        _cookRepository.Delete(cook);
    }

    public List<Recipe> GetRecipesByUsername(string username)
    {
        return _cookRepository.GetRecipesByUsername(username);
    }

    public List<CookReview> GetReviewsForUsername(string username)
    {
        return _cookRepository.GetReviewsForUsername(username);
    }
}