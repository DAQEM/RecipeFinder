using BLL.Entities.Review;

namespace BLL.Data.Review;

public interface IRecipeReviewRepository : IReviewRepository
{
    Entities.Review.Review GetForRecipeId(Guid recipeId);
}