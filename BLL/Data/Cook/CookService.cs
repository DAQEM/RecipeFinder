using BLL.Data.Cook.Credential;
using BLL.Data.Cook.Follower;
using BLL.Data.Recipe;
using BLL.Data.Review;
using BLL.Exceptions;

namespace BLL.Data.Cook;

public class CookService : ICookService
{
    private readonly ICookRepository _cookRepository;
    private readonly ICredentialService _credentialService;
    private readonly IRecipeService _recipeService;
    private readonly ICookReviewService _cookReviewService;
    private readonly IFollowerService _followerService;

    public CookService(ICookRepository cookRepository, ICredentialService credentialService, 
        IRecipeService recipeService, ICookReviewService cookReviewService,
        IFollowerService followerService)
    {
        _cookRepository = cookRepository;
        _credentialService = credentialService;
        _recipeService = recipeService;
        _cookReviewService = cookReviewService;
        _followerService = followerService;
    }
    
    public List<Entities.Cook.Cook> GetAll()
    {
        return _cookRepository.GetAll();
    }
    
    public Entities.Cook.Cook GetById(Guid id)
    {
        Entities.Cook.Cook? cook = _cookRepository.GetById(id);
        return cook ?? throw new NotFoundException(typeof(CookService), nameof(GetById), typeof(Entities.Cook.Cook), id);
    }
    
    public Entities.Cook.Cook GetByUsername(string username)
    {
        Entities.Cook.Cook? cook = _cookRepository.GetByUserName(username);
        return cook ?? throw new NotFoundException(typeof(CookService), nameof(GetByUsername), typeof(Entities.Cook.Cook), username);
    }
    
    public void Add(Entities.Cook.Cook cook)
    {
        _cookRepository.Add(cook);
    }
    
    public void Update(Entities.Cook.Cook cook)
    {
        _cookRepository.Update(cook);
    }
    
    public void UpdateWithCredentials(Entities.Cook.Cook cook)
    {
        Update(cook);
        _credentialService.Update(cook.Credential);
    }
    
    public void Delete(string username)
    {
        _cookRepository.Delete(username);
    }

    public Entities.Cook.Cook GetByUsernameWithRecipes(string username)
    {
        Entities.Cook.Cook cook = GetByUsername(username);
        List<Entities.Recipe.Recipe> recipes = _recipeService.GetByCookIdWithReviews(cook.Id);
        
        cook.SetRecipes(recipes);
        return cook;
    }

    public Entities.Cook.Cook GetByUsernameWithCookReviews(string username)
    {
        Entities.Cook.Cook cook = GetByUsername(username);
        List<Entities.Review.Review> reviews = _cookReviewService.GetByCookId(cook.Id);
        
        cook.SetReviews(reviews);
        return cook;
    }

    public Entities.Cook.Cook GetByUsernameWithCredentials(string username)
    {
        Entities.Cook.Cook cook = GetByUsername(username);
        Entities.Cook.Credential credential = _credentialService.GetByCookId(cook.Id);
        
        cook.SetCredential(credential);
        return cook;
    }

    public Entities.Cook.Cook GetByUsernameWithFollowers(string username)
    {
        Entities.Cook.Cook cook = GetByUsername(username);
        List<Entities.Cook.Cook> followers = _followerService.GetForCook(cook);
        
        cook.SetFollowers(followers);
        return cook;
    }

    public Entities.Cook.Cook GetWithRecipe(Guid recipeId)
    {
        Entities.Recipe.Recipe recipe = _recipeService.GetByIdDetailed(recipeId);
        Entities.Cook.Cook cook = GetById(recipe.CookId);
        
        cook.SetRecipes(new List<Entities.Recipe.Recipe> {recipe});
        return cook;
    }

    public List<Entities.Cook.Cook> GetBySearch(string searchString)
    {
        return _cookRepository.GetBySearch(searchString);
    }
}