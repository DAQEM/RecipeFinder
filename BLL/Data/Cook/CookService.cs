using BLL.Data.Cook.Credential;
using BLL.Data.Recipe;
using BLL.Data.Review;
using BLL.Entities.Review;

namespace BLL.Data.Cook;

public class CookService : ICookService
{
    private readonly ICookRepository _cookRepository;
    private readonly ICredentialService _credentialService;
    private readonly IRecipeService _recipeService;
    private readonly ICookReviewService _cookReviewService;

    public CookService(ICookRepository cookRepository, ICredentialService credentialService, 
        IRecipeService recipeService, ICookReviewService cookReviewService)
    {
        _cookRepository = cookRepository;
        _credentialService = credentialService;
        _recipeService = recipeService;
        _cookReviewService = cookReviewService;
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
    
    public void UpdateWithCredentials(Entities.Cook.Cook cook)
    {
        Update(cook);
        _credentialService.Update(cook.Credential);
    }
    
    public void Delete(string username)
    {
        _cookRepository.Delete(username);
    }

    public Entities.Cook.Cook? GetByUsernameWithRecipes(string username)
    {
        Entities.Cook.Cook? cook = _cookRepository.GetByUserName(username);
        if (cook != null)
        {
            List<Entities.Recipe.Recipe> recipes = _recipeService.GetByCookId(cook.Id);
            return new Entities.Cook.Cook.Builder()
                .FromCook(cook)
                .WithRecipes(recipes.ToArray())
                .Build();
        }
        return null;
    }

    public Entities.Cook.Cook? GetByUsernameWithCookReviews(string username)
    {
        Entities.Cook.Cook? cook = _cookRepository.GetByUserName(username);
        if (cook != null)
        {
            List<CookReview> reviews = _cookReviewService.GetByCookId(cook.Id);
            return new Entities.Cook.Cook.Builder()
                .FromCook(cook)
                .WithReviews(reviews.ToArray())
                .Build();
        }
        return null;
    }

    public Entities.Cook.Cook? GetByRecipeIdWithRecipe(Guid recipeId)
    {
        Entities.Recipe.Recipe? recipe = _recipeService.GetById(recipeId);
        if (recipe == null) return null;
        Entities.Cook.Cook? cook = _cookRepository.GetById(recipe.CookId);
        return cook == null ? null : 
            new Entities.Cook.Cook.Builder()
                .FromCook(cook)
                .WithRecipes(new[] {recipe})
                .Build();
    }
}