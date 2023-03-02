using BLL.Entities.Review;

namespace BLL.Data.Review;

public class RecipeReviewService : ReviewService<RecipeReview>
{
    private readonly IRecipeReviewRepository _recipeReviewRepository;
    
    public RecipeReviewService(IRecipeReviewRepository recipeReviewRepository) 
        : base(recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public RecipeReview GetForRecipeId(Guid recipeId)
    {
        return _recipeReviewRepository.GetForRecipeId(recipeId);
    }
}