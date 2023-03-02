using BLL.Entities.Review;

namespace BLL.Data.Review;

public class CookReviewService : ReviewService<CookReview>
{
    private readonly ICookReviewRepository _recipeReviewRepository;
    
    public CookReviewService(ICookReviewRepository recipeReviewRepository) 
        : base(recipeReviewRepository)
    {
        _recipeReviewRepository = recipeReviewRepository;
    }
    
    public CookReview GetForCookId(Guid cookId)
    {
        return _recipeReviewRepository.GetForCookId(cookId);
    }
}