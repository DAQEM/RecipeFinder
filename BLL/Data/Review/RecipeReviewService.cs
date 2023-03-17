using BLL.Entities.Review;

namespace BLL.Data.Review;

public class RecipeReviewService : IRecipeReviewService
{
    private readonly IRecipeReviewRepository _recipeReviewRepository;
    
    public RecipeReviewService(IRecipeReviewRepository recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public Entities.Review.Review GetForRecipeId(Guid recipeId)
    {
        return _recipeReviewRepository.GetForRecipeId(recipeId);
    }

    public List<Entities.Review.Review> GetAll()
    {
        throw new NotImplementedException();
    }

    public Entities.Review.Review GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Entities.Review.Review> GetByCookId(Guid cookId)
    {
        throw new NotImplementedException();
    }

    public List<Entities.Review.Review> GetByRating(int rating)
    {
        throw new NotImplementedException();
    }

    public void Add(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }

    public void Update(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }

    public void Delete(Entities.Review.Review review)
    {
        throw new NotImplementedException();
    }
}