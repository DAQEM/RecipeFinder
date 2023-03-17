using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface IRecipeReviewService : IReviewService
{
    Entities.Review.Review GetForRecipeId(Guid recipeId);
}