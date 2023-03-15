using BLL.Entities.Review;

namespace BLL.Data.Review;

public class RecipeReviewService : IRecipeReviewService
{
    private readonly IRecipeReviewRepository _recipeReviewRepository;
    
    public RecipeReviewService(IRecipeReviewRepository recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public RecipeReview GetForRecipeId(Guid recipeId)
    {
        return _recipeReviewRepository.GetForRecipeId(recipeId);
    }

    public List<RecipeReview> GetAll()
    {
        throw new NotImplementedException();
    }

    public RecipeReview GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<RecipeReview> GetByCookId(Guid cookId)
    {
        throw new NotImplementedException();
    }

    public List<RecipeReview> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(RecipeReview review)
    {
        throw new NotImplementedException();
    }

    public void Update(RecipeReview review)
    {
        throw new NotImplementedException();
    }

    public void Delete(RecipeReview review)
    {
        throw new NotImplementedException();
    }
}